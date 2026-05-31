using System;
using System.Windows.Forms;
using IngressosFM.Database;

namespace IngressosFM.Forms
{
    public partial class EventoForm : Form
    {
        public EventoForm()
        {
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                dgvEventos.DataSource = DbHelper.ExecuteQuery(
                    "SELECT id_evento, nome, data_inicio, data_fim FROM dbo.Evento ORDER BY id_evento");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro a carregar eventos:\n" + ex.Message);
            }
        }

        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            dtpInicio.Value = DateTime.Today;
            dtpFim.Value = DateTime.Today;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            txtId.Text = DbHelper.NextId("Evento", "id_evento").ToString();
            txtNome.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("ID inválido."); return;
            }
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Nome obrigatório."); return;
            }
            if (dtpFim.Value < dtpInicio.Value)
            {
                MessageBox.Show("Data fim tem de ser >= data início."); return;
            }

            try
            {
                DbHelper.ExecuteNonQuery(
                    "EXEC dbo.sp_GuardarEvento @id, @nome, @di, @df",
                    DbHelper.P("@id",   id),
                    DbHelper.P("@nome", txtNome.Text.Trim()),
                    DbHelper.P("@di",   dtpInicio.Value.Date),
                    DbHelper.P("@df",   dtpFim.Value.Date));

                CarregarDados();
                LimparCampos();
                MessageBox.Show("Guardado com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro a guardar:\n" + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Seleciona uma linha primeiro."); return;
            }
            if (MessageBox.Show("Eliminar evento " + id + "?", "Confirmar",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                DbHelper.ExecuteNonQuery(
                    "EXEC dbo.sp_EliminarEvento @id",
                    DbHelper.P("@id", id));
                CarregarDados();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro a eliminar (verifica chaves estrangeiras):\n" + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e) => CarregarDados();

        private void dgvEventos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvEventos.Rows[e.RowIndex];
            txtId.Text = row.Cells["id_evento"].Value.ToString();
            txtNome.Text = row.Cells["nome"].Value.ToString();
            dtpInicio.Value = Convert.ToDateTime(row.Cells["data_inicio"].Value);
            dtpFim.Value = Convert.ToDateTime(row.Cells["data_fim"].Value);
        }
    }
}
