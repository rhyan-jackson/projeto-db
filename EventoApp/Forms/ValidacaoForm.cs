using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using EventoApp.Database;

namespace EventoApp.Forms
{
    /// <summary>
    /// Simulação de leitura de QR num ponto de acesso.
    /// Procura o token pelo código_qr, verifica se está "Ativo" e regista
    /// a validação (Permitido / Negado) na tabela Validacao.
    /// </summary>
    public partial class ValidacaoForm : Form
    {
        public ValidacaoForm()
        {
            InitializeComponent();
            CarregarPontos();
            CarregarHistorico();
        }

        private void CarregarPontos()
        {
            var t = DbHelper.ExecuteQuery(@"
                SELECT id_ponto_de_acesso, designacao + ' (' + sentido + ')' AS desc_ponto
                FROM dbo.Ponto_de_Acesso ORDER BY designacao");
            cmbPonto.DisplayMember = "desc_ponto";
            cmbPonto.ValueMember = "id_ponto_de_acesso";
            cmbPonto.DataSource = t;
        }

        private void CarregarHistorico()
        {
            // Nota: v.data_hora é rowversion - não é data. Para ordenar usa-se id_validacao DESC.
            dgv.DataSource = DbHelper.ExecuteQuery(@"
                SELECT TOP 100 v.id_validacao, v.codigo_lido, v.resultado,
                       pa.designacao AS ponto
                FROM dbo.Validacao v
                INNER JOIN dbo.Ponto_de_Acesso pa ON pa.id_ponto_de_acesso = v.id_ponto_de_acesso
                ORDER BY v.id_validacao DESC");
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            var qr = txtQr.Text.Trim();
            if (string.IsNullOrWhiteSpace(qr)) { MessageBox.Show("Lê / introduz um código QR."); return; }
            if (cmbPonto.SelectedValue == null) { MessageBox.Show("Escolhe um ponto de acesso."); return; }

            using (var conn = DbHelper.GetConnection())
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    int? idToken = null;
                    string status = null;

                    using (var cmd = new SqlCommand(
                        "SELECT id_token, status FROM dbo.Token WHERE codigo_qr=@qr", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@qr", qr);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                idToken = r.GetInt32(0);
                                status = r.GetString(1);
                            }
                        }
                    }

                    string resultado;
                    if (idToken == null) resultado = "Negado - Token desconhecido";
                    else if (!status.Equals("Ativo", StringComparison.OrdinalIgnoreCase))
                        resultado = "Negado - Status: " + status;
                    else
                        resultado = "Permitido";

                    // Se não temos token, precisamos de um id_token válido na tabela Validacao
                    // (NOT NULL FK). Convenção: se desconhecido, não conseguimos registar.
                    if (idToken == null)
                    {
                        lblResultado.Text = "✗ " + resultado;
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                        tx.Rollback();
                        return;
                    }

                    int idVal = NextIdInTx("Validacao", "id_validacao", conn, tx);
                    // NOTA: data_hora é coluna 'timestamp' (= rowversion) no SQL Server,
                    // ou seja, é gerada automaticamente. Por isso NÃO a incluímos no INSERT.
                    using (var cmd = new SqlCommand(@"
                        INSERT INTO dbo.Validacao
                            (id_validacao, codigo_lido, resultado, id_ponto_de_acesso, id_token)
                        VALUES(@id, @qr, @res, @pa, @tk)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", idVal);
                        cmd.Parameters.AddWithValue("@qr", qr);
                        cmd.Parameters.AddWithValue("@res", resultado);
                        cmd.Parameters.AddWithValue("@pa", cmbPonto.SelectedValue);
                        cmd.Parameters.AddWithValue("@tk", idToken);
                        cmd.ExecuteNonQuery();
                    }

                    // Se permitido, marca token como "Usado" (opcional - depende da regra
                    // do projeto se um token é "single-use" ou não)
                    if (resultado == "Permitido" && chkUsadoUnico.Checked)
                    {
                        using (var cmd = new SqlCommand(
                            "UPDATE dbo.Token SET status='Usado' WHERE id_token=@id", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@id", idToken);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tx.Commit();

                    lblResultado.Text = (resultado == "Permitido" ? "✓ " : "✗ ") + resultado;
                    lblResultado.ForeColor = resultado == "Permitido"
                        ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                    CarregarHistorico();
                    txtQr.Clear(); txtQr.Focus();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private static int NextIdInTx(string tabela, string col, SqlConnection conn, SqlTransaction tx)
        {
            using (var cmd = new SqlCommand(
                $"SELECT ISNULL(MAX([{col}]),0)+1 FROM dbo.[{tabela}]", conn, tx))
                return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void btnAtualizar_Click(object sender, EventArgs e) => CarregarHistorico();
    }
}
