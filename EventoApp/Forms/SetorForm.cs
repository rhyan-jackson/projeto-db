using System;
using System.Windows.Forms;
using EventoApp.Database;

namespace EventoApp.Forms
{
    public partial class SetorForm : Form
    {
        public SetorForm()
        {
            InitializeComponent();
            CarregarEventos();
            CarregarDados();
        }

        private void CarregarEventos()
        {
            try
            {
                var t = DbHelper.ExecuteQuery(
                    "SELECT id_evento, nome FROM dbo.Evento ORDER BY nome");
                cmbEvento.DisplayMember = "nome";
                cmbEvento.ValueMember = "id_evento";
                cmbEvento.DataSource = t;
            }
            catch (Exception ex) { MessageBox.Show("Erro a carregar eventos: " + ex.Message); }
        }

        private void CarregarDados()
        {
            try
            {
                dgv.DataSource = DbHelper.ExecuteQuery(@"
                    SELECT s.id_setor, s.id_evento, e.nome AS evento
                    FROM dbo.Setor s
                    INNER JOIN dbo.Evento e ON e.id_evento = s.id_evento
                    ORDER BY s.id_setor");
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
        }

        private void Limpar()
        {
            txtId.Clear();
            if (cmbEvento.Items.Count > 0) cmbEvento.SelectedIndex = 0;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
            txtId.Text = DbHelper.NextId("Setor", "id_setor").ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) { MessageBox.Show("ID inválido."); return; }
            if (cmbEvento.SelectedValue == null) { MessageBox.Show("Escolhe um evento."); return; }

            try
            {
                var sql = @"
                    IF EXISTS (SELECT 1 FROM dbo.Setor WHERE id_setor = @id)
                        UPDATE dbo.Setor SET id_evento=@ev WHERE id_setor=@id
                    ELSE
                        INSERT INTO dbo.Setor(id_setor, id_evento) VALUES(@id, @ev)";
                DbHelper.ExecuteNonQuery(sql,
                    DbHelper.P("@id", id),
                    DbHelper.P("@ev", cmbEvento.SelectedValue));
                CarregarDados();
                Limpar();
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;
            if (MessageBox.Show("Eliminar setor?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                DbHelper.ExecuteNonQuery("DELETE FROM dbo.Setor WHERE id_setor=@id",
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
            txtId.Text = r.Cells["id_setor"].Value.ToString();
            cmbEvento.SelectedValue = r.Cells["id_evento"].Value;
        }
    }
}
