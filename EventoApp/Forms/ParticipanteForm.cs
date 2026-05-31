using System;
using System.Windows.Forms;
using EventoApp.Database;

namespace EventoApp.Forms
{
    public partial class ParticipanteForm : Form
    {
        public ParticipanteForm()
        {
            InitializeComponent();
            CarregarEventos();
            CarregarStands();
            CarregarDados();
            rdbVisitante.Checked = true;
            AtualizarVisibilidade();
        }

        private void CarregarEventos()
        {
            var t = DbHelper.ExecuteQuery(
                "SELECT id_evento, nome FROM dbo.Evento ORDER BY nome");
            cmbEvento.DisplayMember = "nome";
            cmbEvento.ValueMember = "id_evento";
            cmbEvento.DataSource = t;
        }

        private void CarregarStands()
        {
            var t = DbHelper.ExecuteQuery(
                "SELECT id_stand FROM dbo.Stand ORDER BY id_stand");
            cmbStand.DisplayMember = "id_stand";
            cmbStand.ValueMember = "id_stand";
            cmbStand.DataSource = t;
        }

        private void CarregarDados()
        {
            dgv.DataSource = DbHelper.ExecuteQuery(
                "SELECT * FROM dbo.vw_Participantes ORDER BY id_participante");
        }

        private void Limpar()
        {
            txtId.Clear(); txtNif.Clear(); txtNome.Clear(); txtTel.Clear();
            txtEmpresa.Clear(); txtProfissao.Clear();
            if (cmbEvento.Items.Count > 0) cmbEvento.SelectedIndex = 0;
            if (cmbStand.Items.Count > 0) cmbStand.SelectedIndex = 0;
            rdbVisitante.Checked = true;
            AtualizarVisibilidade();
        }

        private void AtualizarVisibilidade()
        {
            bool isExp = rdbExpositor.Checked;
            txtEmpresa.Enabled = isExp;
            cmbStand.Enabled = isExp;
            txtProfissao.Enabled = !isExp;
        }

        private void rdb_CheckedChanged(object sender, EventArgs e) => AtualizarVisibilidade();

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
            txtId.Text = DbHelper.NextId("Participante", "id_participante").ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) { MessageBox.Show("ID inválido."); return; }
            if (string.IsNullOrWhiteSpace(txtNif.Text)) { MessageBox.Show("NIF obrigatório."); return; }
            if (string.IsNullOrWhiteSpace(txtNome.Text)) { MessageBox.Show("Nome obrigatório."); return; }
            if (cmbEvento.SelectedValue == null) { MessageBox.Show("Escolhe evento."); return; }

            try
            {
                DbHelper.ExecuteNonQuery(
                    "EXEC dbo.sp_GuardarParticipante @id, @nif, @nome, @tel, @ev, @tipo, @emp, @stand, @prof",
                    DbHelper.P("@id",    id),
                    DbHelper.P("@nif",   txtNif.Text.Trim()),
                    DbHelper.P("@nome",  txtNome.Text.Trim()),
                    DbHelper.P("@tel",   string.IsNullOrWhiteSpace(txtTel.Text) ? (object)DBNull.Value : txtTel.Text.Trim()),
                    DbHelper.P("@ev",    cmbEvento.SelectedValue),
                    DbHelper.P("@tipo",  rdbExpositor.Checked ? "Expositor" : "Visitante"),
                    DbHelper.P("@emp",   string.IsNullOrWhiteSpace(txtEmpresa.Text) ? (object)DBNull.Value : txtEmpresa.Text.Trim()),
                    DbHelper.P("@stand", cmbStand.SelectedValue ?? (object)DBNull.Value),
                    DbHelper.P("@prof",  string.IsNullOrWhiteSpace(txtProfissao.Text) ? (object)DBNull.Value : txtProfissao.Text.Trim()));
                CarregarDados(); Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro a guardar:\n" + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;
            if (MessageBox.Show("Eliminar participante (e subtipo)?", "Confirmar",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                DbHelper.ExecuteNonQuery(
                    "EXEC dbo.sp_EliminarParticipante @id",
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
            txtId.Text = r.Cells["id_participante"].Value.ToString();
            txtNif.Text = r.Cells["nif"].Value?.ToString();
            txtNome.Text = r.Cells["nome_completo"].Value?.ToString();
            txtTel.Text = r.Cells["telemovel"].Value?.ToString();
            cmbEvento.SelectedValue = r.Cells["id_evento"].Value;

            var tipo = r.Cells["tipo"].Value?.ToString();
            if (tipo == "Expositor")
            {
                rdbExpositor.Checked = true;
                txtEmpresa.Text = r.Cells["nome_empresa"].Value?.ToString();
                if (r.Cells["id_stand"].Value != DBNull.Value && r.Cells["id_stand"].Value != null)
                    cmbStand.SelectedValue = r.Cells["id_stand"].Value;
            }
            else
            {
                rdbVisitante.Checked = true;
                txtProfissao.Text = r.Cells["profissao"].Value?.ToString();
            }
            AtualizarVisibilidade();
        }
    }
}
