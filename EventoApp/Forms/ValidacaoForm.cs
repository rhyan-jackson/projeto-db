using System;
using System.Windows.Forms;
using EventoApp.Database;

namespace EventoApp.Forms
{
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
            dgv.DataSource = DbHelper.ExecuteQuery(
                "SELECT * FROM dbo.vw_HistoricoValidacoes");
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            var qr = txtQr.Text.Trim();
            if (string.IsNullOrWhiteSpace(qr)) { MessageBox.Show("Lê / introduz um código QR."); return; }
            if (cmbPonto.SelectedValue == null) { MessageBox.Show("Escolhe um ponto de acesso."); return; }

            try
            {
                var dt = DbHelper.ExecuteQuery(
                    "EXEC dbo.sp_ValidarToken @qr, @pa, @single",
                    DbHelper.P("@qr",     qr),
                    DbHelper.P("@pa",     cmbPonto.SelectedValue),
                    DbHelper.P("@single", chkUsadoUnico.Checked ? 1 : 0));

                var resultado = dt.Rows[0]["resultado"].ToString();
                lblResultado.Text = (resultado == "Permitido" ? "✓ " : "✗ ") + resultado;
                lblResultado.ForeColor = resultado == "Permitido"
                    ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                CarregarHistorico();
                txtQr.Clear(); txtQr.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e) => CarregarHistorico();
    }
}
