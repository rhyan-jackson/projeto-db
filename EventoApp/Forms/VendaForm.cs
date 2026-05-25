using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using EventoApp.Database;

namespace EventoApp.Forms
{
    /// <summary>
    /// Operação composta: regista uma Venda + um Ingresso (com Token associado)
    /// + um Pagamento. Tudo numa só transação.
    /// </summary>
    public partial class VendaForm : Form
    {
        private readonly string _utilizadorEmail;

        public VendaForm(string utilizadorEmail)
        {
            InitializeComponent();
            _utilizadorEmail = utilizadorEmail;
            CarregarParticipantes();
            CarregarTiposAcesso();
            CarregarMetodos();
            CarregarVendas();
        }

        private void CarregarParticipantes()
        {
            var t = DbHelper.ExecuteQuery(@"
                SELECT id_participante, nome_completo FROM dbo.Participante
                ORDER BY nome_completo");
            cmbParticipante.DisplayMember = "nome_completo";
            cmbParticipante.ValueMember = "id_participante";
            cmbParticipante.DataSource = t;
        }

        private void CarregarTiposAcesso()
        {
            var t = DbHelper.ExecuteQuery(
                "SELECT id_tipo, nome_perfil FROM dbo.Tipo_de_Acesso ORDER BY nome_perfil");
            cmbTipo.DisplayMember = "nome_perfil";
            cmbTipo.ValueMember = "id_tipo";
            cmbTipo.DataSource = t;
        }

        private void CarregarMetodos()
        {
            cmbMetodo.Items.AddRange(new object[]
            {
                "Multibanco", "MBWay", "Cartão de Crédito", "Numerário", "Transferência"
            });
            cmbMetodo.SelectedIndex = 0;
        }

        private void CarregarVendas()
        {
            dgv.DataSource = DbHelper.ExecuteQuery(@"
                SELECT v.id_venda, v.data_emissao, v.valor_total,
                       u.email AS utilizador,
                       (SELECT COUNT(*) FROM dbo.Ingresso i WHERE i.id_venda = v.id_venda) AS n_ingressos
                FROM dbo.Venda v
                INNER JOIN dbo.Utilizador u ON u.id_utilizador = v.id_utilizador
                ORDER BY v.id_venda DESC");
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            if (cmbParticipante.SelectedValue == null)
            { MessageBox.Show("Escolhe participante."); return; }
            if (cmbTipo.SelectedValue == null)
            { MessageBox.Show("Escolhe tipo de acesso."); return; }
            if (!decimal.TryParse(txtPreco.Text.Replace(',', '.'),
                NumberStyles.Any, CultureInfo.InvariantCulture, out decimal preco) || preco <= 0)
            { MessageBox.Show("Preço inválido."); return; }
            if (cmbMetodo.SelectedItem == null)
            { MessageBox.Show("Escolhe método de pagamento."); return; }

            using (var conn = DbHelper.GetConnection())
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    // 1) Obter id_utilizador a partir do email da sessão
                    int idUtilizador;
                    using (var cmd = new SqlCommand(
                        "SELECT id_utilizador FROM dbo.Utilizador WHERE email=@email", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@email", _utilizadorEmail);
                        var obj = cmd.ExecuteScalar();
                        if (obj == null)
                            throw new Exception("Utilizador da sessão não encontrado.");
                        idUtilizador = Convert.ToInt32(obj);
                    }

                    // 2) Próximos IDs
                    int idVenda = NextIdInTx("Venda", "id_venda", conn, tx);
                    int idToken = NextIdInTx("Token", "id_token", conn, tx);
                    int idPagamento = NextIdInTx("Pagamento", "id_pagamento", conn, tx);

                    // 3) Criar Venda
                    using (var cmd = new SqlCommand(@"
                        INSERT INTO dbo.Venda(id_venda, data_emissao, valor_total, id_utilizador)
                        VALUES(@id, @data, @valor, @ut)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", idVenda);
                        cmd.Parameters.AddWithValue("@data", DateTime.Today);
                        cmd.Parameters.AddWithValue("@valor", preco);
                        cmd.Parameters.AddWithValue("@ut", idUtilizador);
                        cmd.ExecuteNonQuery();
                    }

                    // 4) Criar Token (necessário para o Ingresso)
                    var qr = "QR-" + Guid.NewGuid().ToString("N").Substring(0, 12).ToUpper();
                    using (var cmd = new SqlCommand(@"
                        INSERT INTO dbo.Token(id_token, codigo_qr, status, id_tipo)
                        VALUES(@id, @qr, 'Ativo', @tp)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", idToken);
                        cmd.Parameters.AddWithValue("@qr", qr);
                        cmd.Parameters.AddWithValue("@tp", cmbTipo.SelectedValue);
                        cmd.ExecuteNonQuery();
                    }

                    // 5) Criar Ingresso
                    using (var cmd = new SqlCommand(@"
                        INSERT INTO dbo.Ingresso(id_token, preco_pago, data_validade, id_venda, id_participante)
                        VALUES(@idT, @preco, @validade, @idV, @part)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@idT", idToken);
                        cmd.Parameters.AddWithValue("@preco", preco);
                        cmd.Parameters.AddWithValue("@validade", dtpValidade.Value.Date);
                        cmd.Parameters.AddWithValue("@idV", idVenda);
                        cmd.Parameters.AddWithValue("@part", cmbParticipante.SelectedValue);
                        cmd.ExecuteNonQuery();
                    }

                    // 6) Criar Pagamento
                    using (var cmd = new SqlCommand(@"
                        INSERT INTO dbo.Pagamento(id_pagamento, metodo, referencia, valor, id_venda)
                        VALUES(@id, @met, @ref, @val, @idV)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", idPagamento);
                        cmd.Parameters.AddWithValue("@met", cmbMetodo.SelectedItem);
                        cmd.Parameters.AddWithValue("@ref",
                            string.IsNullOrWhiteSpace(txtReferencia.Text)
                            ? (object)DBNull.Value : txtReferencia.Text.Trim());
                        cmd.Parameters.AddWithValue("@val", preco);
                        cmd.Parameters.AddWithValue("@idV", idVenda);
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();

                    MessageBox.Show($"Venda #{idVenda} registada.\nToken QR: {qr}",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarVendas();
                    txtPreco.Clear();
                    txtReferencia.Clear();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("Erro a registar venda:\n" + ex.Message);
                }
            }
        }

        private static int NextIdInTx(string tabela, string col, SqlConnection conn, SqlTransaction tx)
        {
            using (var cmd = new SqlCommand(
                $"SELECT ISNULL(MAX([{col}]),0)+1 FROM dbo.[{tabela}]", conn, tx))
                return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void btnAtualizar_Click(object sender, EventArgs e) => CarregarVendas();
    }
}
