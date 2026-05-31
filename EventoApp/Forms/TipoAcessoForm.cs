using System;
using System.Windows.Forms;
using IngressosFM.Database;

namespace IngressosFM.Forms
{
    public partial class TipoAcessoForm : Form
    {
        public TipoAcessoForm()
        {
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
            dgv.DataSource = DbHelper.ExecuteQuery(
                "SELECT id_tipo, nome_perfil FROM dbo.Tipo_de_Acesso ORDER BY id_tipo");
        }

        private void Limpar() { txtId.Clear(); txtNome.Clear(); }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
            txtId.Text = DbHelper.NextId("Tipo_de_Acesso", "id_tipo").ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) { MessageBox.Show("ID inválido."); return; }
            if (string.IsNullOrWhiteSpace(txtNome.Text)) { MessageBox.Show("Nome obrigatório."); return; }
            try
            {
                DbHelper.ExecuteNonQuery(
                    "EXEC dbo.sp_GuardarTipoAcesso @id, @nome",
                    DbHelper.P("@id",   id),
                    DbHelper.P("@nome", txtNome.Text.Trim()));
                CarregarDados(); Limpar();
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;
            if (MessageBox.Show("Eliminar?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                DbHelper.ExecuteNonQuery(
                    "EXEC dbo.sp_EliminarTipoAcesso @id",
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
            txtId.Text = r.Cells["id_tipo"].Value.ToString();
            txtNome.Text = r.Cells["nome_perfil"].Value.ToString();
        }
    }
}
