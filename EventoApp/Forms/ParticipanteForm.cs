using System;
using System.Data.SqlClient;
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
            dgv.DataSource = DbHelper.ExecuteQuery(@"
                SELECT p.id_participante, p.nif, p.nome_completo, p.telemovel, p.id_evento,
                       CASE WHEN ex.id_participante IS NOT NULL THEN 'Expositor'
                            WHEN vi.id_participante IS NOT NULL THEN 'Visitante'
                            ELSE '?' END AS tipo,
                       ex.nome_empresa, ex.id_stand, vi.profissao
                FROM dbo.Participante p
                LEFT JOIN dbo.Expositor ex ON ex.id_participante = p.id_participante
                LEFT JOIN dbo.Visitante vi ON vi.id_participante = p.id_participante
                ORDER BY p.id_participante");
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

            // Transação: o participante e o seu subtipo (Expositor/Visitante)
            // têm de ser gravados juntos.
            using (var conn = DbHelper.GetConnection())
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    // 1) UPSERT no Participante
                    using (var cmd = new SqlCommand(@"
                        IF EXISTS (SELECT 1 FROM dbo.Participante WHERE id_participante=@id)
                            UPDATE dbo.Participante
                            SET nif=@nif, nome_completo=@nome, telemovel=@tel, id_evento=@ev
                            WHERE id_participante=@id
                        ELSE
                            INSERT INTO dbo.Participante(id_participante, nif, nome_completo, telemovel, id_evento)
                            VALUES(@id, @nif, @nome, @tel, @ev)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nif", txtNif.Text.Trim());
                        cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
                        cmd.Parameters.AddWithValue("@tel",
                            string.IsNullOrWhiteSpace(txtTel.Text) ? (object)DBNull.Value : txtTel.Text.Trim());
                        cmd.Parameters.AddWithValue("@ev", cmbEvento.SelectedValue);
                        cmd.ExecuteNonQuery();
                    }

                    // 2) Apaga eventual subtipo antigo (se trocou de tipo)
                    using (var cmd = new SqlCommand(
                        "DELETE FROM dbo.Expositor WHERE id_participante=@id; " +
                        "DELETE FROM dbo.Visitante WHERE id_participante=@id;", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    // 3) Insere o subtipo correto
                    if (rdbExpositor.Checked)
                    {
                        using (var cmd = new SqlCommand(@"
                            INSERT INTO dbo.Expositor(id_participante, nome_empresa, id_stand, data_inicio_ocupacao)
                            VALUES(@id, @emp, @stand, @data)", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@emp",
                                string.IsNullOrWhiteSpace(txtEmpresa.Text) ? (object)DBNull.Value : txtEmpresa.Text.Trim());
                            cmd.Parameters.AddWithValue("@stand",
                                cmbStand.SelectedValue ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@data", DateTime.Today);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (var cmd = new SqlCommand(@"
                            INSERT INTO dbo.Visitante(id_participante, profissao)
                            VALUES(@id, @prof)", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@prof",
                                string.IsNullOrWhiteSpace(txtProfissao.Text) ? (object)DBNull.Value : txtProfissao.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tx.Commit();
                    CarregarDados(); Limpar();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("Erro a guardar:\n" + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;
            if (MessageBox.Show("Eliminar participante (e subtipo)?", "Confirmar",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            using (var conn = DbHelper.GetConnection())
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    using (var cmd = new SqlCommand(
                        "DELETE FROM dbo.Expositor WHERE id_participante=@id; " +
                        "DELETE FROM dbo.Visitante WHERE id_participante=@id; " +
                        "DELETE FROM dbo.Participante WHERE id_participante=@id;", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    tx.Commit();
                    CarregarDados(); Limpar();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
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
