using System;
using System.Windows.Forms;
using IngressosFM.Database;

namespace IngressosFM.Forms
{
    public partial class TokenForm : Form
    {
        public TokenForm()
        {
            InitializeComponent();
            CarregarTipos();
            CarregarDados();
            cmbStatus.Items.AddRange(new object[] { "Ativo", "Usado", "Cancelado", "Expirado" });
        }

        private void CarregarTipos()
        {
            var t = DbHelper.ExecuteQuery(
                "SELECT id_tipo, nome_perfil FROM dbo.Tipo_de_Acesso ORDER BY nome_perfil");
            cmbTipo.DisplayMember = "nome_perfil";
            cmbTipo.ValueMember = "id_tipo";
            cmbTipo.DataSource = t;
        }

        private void CarregarDados()
        {
            dgv.DataSource = DbHelper.ExecuteQuery(
                "SELECT * FROM dbo.vw_Tokens ORDER BY id_token");
        }

        private void Limpar()
        {
            txtId.Clear(); txtQr.Clear();
            cmbStatus.SelectedIndex = 0;
            if (cmbTipo.Items.Count > 0) cmbTipo.SelectedIndex = 0;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
            txtId.Text = DbHelper.NextId("Token", "id_token").ToString();
            txtQr.Text = "QR-" + Guid.NewGuid().ToString("N").Substring(0, 12).ToUpper();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) { MessageBox.Show("ID inválido."); return; }
            if (string.IsNullOrWhiteSpace(txtQr.Text)) { MessageBox.Show("QR obrigatório."); return; }
            if (cmbStatus.SelectedItem == null) { MessageBox.Show("Status obrigatório."); return; }
            if (cmbTipo.SelectedValue == null) { MessageBox.Show("Tipo obrigatório."); return; }

            try
            {
                DbHelper.ExecuteNonQuery(
                    "EXEC dbo.sp_GuardarToken @id, @qr, @st, @tp",
                    DbHelper.P("@id", id),
                    DbHelper.P("@qr", txtQr.Text.Trim()),
                    DbHelper.P("@st", cmbStatus.SelectedItem),
                    DbHelper.P("@tp", cmbTipo.SelectedValue));
                CarregarDados(); Limpar();
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;
            if (MessageBox.Show("Eliminar token?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                DbHelper.ExecuteNonQuery(
                    "EXEC dbo.sp_EliminarToken @id",
                    DbHelper.P("@id", id));
                CarregarDados(); Limpar();
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
        }

        private void btnAtualizar_Click(object sender, EventArgs e) => CarregarDados();

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgv.Rows[e.RowIndex];
            txtId.Text = r.Cells["id_token"].Value.ToString();
            txtQr.Text = r.Cells["codigo_qr"].Value.ToString();
            cmbStatus.SelectedItem = r.Cells["status"].Value.ToString();
            cmbTipo.SelectedValue = r.Cells["id_tipo"].Value;
        }
    }
}
