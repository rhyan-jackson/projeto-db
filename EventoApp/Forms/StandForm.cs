using System;
using System.Globalization;
using System.Windows.Forms;
using EventoApp.Database;

namespace EventoApp.Forms
{
    public partial class StandForm : Form
    {
        public StandForm()
        {
            InitializeComponent();
            CarregarSetores();
            CarregarDados();
        }

        private void CarregarSetores()
        {
            var t = DbHelper.ExecuteQuery(@"
                SELECT s.id_setor, CAST(s.id_setor AS varchar) + ' (' + e.nome + ')' AS descricao
                FROM dbo.Setor s INNER JOIN dbo.Evento e ON e.id_evento = s.id_evento
                ORDER BY s.id_setor");
            cmbSetor.DisplayMember = "descricao";
            cmbSetor.ValueMember = "id_setor";
            cmbSetor.DataSource = t;
        }

        private void CarregarDados()
        {
            dgv.DataSource = DbHelper.ExecuteQuery(@"
                SELECT id_stand, area_m2, id_setor FROM dbo.Stand ORDER BY id_stand");
        }

        private void Limpar()
        {
            txtId.Clear(); txtArea.Clear();
            if (cmbSetor.Items.Count > 0) cmbSetor.SelectedIndex = 0;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
            txtId.Text = DbHelper.NextId("Stand", "id_stand").ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) { MessageBox.Show("ID inválido."); return; }
            if (!decimal.TryParse(txtArea.Text.Replace(',', '.'),
                NumberStyles.Any, CultureInfo.InvariantCulture, out decimal area))
            { MessageBox.Show("Área inválida."); return; }
            if (cmbSetor.SelectedValue == null) { MessageBox.Show("Escolhe setor."); return; }

            try
            {
                DbHelper.ExecuteNonQuery(
                    "EXEC dbo.sp_GuardarStand @id, @area, @setor",
                    DbHelper.P("@id",    id),
                    DbHelper.P("@area",  area),
                    DbHelper.P("@setor", cmbSetor.SelectedValue));
                CarregarDados(); Limpar();
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;
            if (MessageBox.Show("Eliminar stand?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                DbHelper.ExecuteNonQuery(
                    "EXEC dbo.sp_EliminarStand @id",
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
            txtId.Text = r.Cells["id_stand"].Value.ToString();
            txtArea.Text = Convert.ToDecimal(r.Cells["area_m2"].Value)
                .ToString(CultureInfo.InvariantCulture);
            cmbSetor.SelectedValue = r.Cells["id_setor"].Value;
        }
    }
}
