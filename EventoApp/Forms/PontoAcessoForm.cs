using System;
using System.Windows.Forms;
using EventoApp.Database;

namespace EventoApp.Forms
{
    public partial class PontoAcessoForm : Form
    {
        public PontoAcessoForm()
        {
            InitializeComponent();
            CarregarSetores();
            CarregarDados();
            cmbSentido.Items.AddRange(new object[] { "Entrada", "Saída", "Ambos" });
        }

        private void CarregarSetores()
        {
            var t = DbHelper.ExecuteQuery("SELECT id_setor FROM dbo.Setor ORDER BY id_setor");
            cmbSetor.DisplayMember = "id_setor";
            cmbSetor.ValueMember = "id_setor";
            cmbSetor.DataSource = t;
        }

        private void CarregarDados()
        {
            dgv.DataSource = DbHelper.ExecuteQuery(@"
                SELECT id_ponto_de_acesso, designacao, sentido, id_setor
                FROM dbo.Ponto_de_Acesso ORDER BY id_ponto_de_acesso");
        }

        private void Limpar()
        {
            txtId.Clear(); txtDesignacao.Clear();
            cmbSentido.SelectedIndex = -1;
            if (cmbSetor.Items.Count > 0) cmbSetor.SelectedIndex = 0;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
            txtId.Text = DbHelper.NextId("Ponto_de_Acesso", "id_ponto_de_acesso").ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) { MessageBox.Show("ID inválido."); return; }
            if (string.IsNullOrWhiteSpace(txtDesignacao.Text)) { MessageBox.Show("Designação obrigatória."); return; }
            if (cmbSetor.SelectedValue == null) { MessageBox.Show("Escolhe setor."); return; }

            try
            {
                var sql = @"
                    IF EXISTS (SELECT 1 FROM dbo.Ponto_de_Acesso WHERE id_ponto_de_acesso=@id)
                        UPDATE dbo.Ponto_de_Acesso SET designacao=@d, sentido=@s, id_setor=@set
                        WHERE id_ponto_de_acesso=@id
                    ELSE
                        INSERT INTO dbo.Ponto_de_Acesso(id_ponto_de_acesso, designacao, sentido, id_setor)
                        VALUES(@id, @d, @s, @set)";
                DbHelper.ExecuteNonQuery(sql,
                    DbHelper.P("@id", id),
                    DbHelper.P("@d", txtDesignacao.Text.Trim()),
                    DbHelper.P("@s", cmbSentido.SelectedItem),
                    DbHelper.P("@set", cmbSetor.SelectedValue));
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
                DbHelper.ExecuteNonQuery("DELETE FROM dbo.Ponto_de_Acesso WHERE id_ponto_de_acesso=@id",
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
            txtId.Text = r.Cells["id_ponto_de_acesso"].Value.ToString();
            txtDesignacao.Text = r.Cells["designacao"].Value?.ToString();
            cmbSentido.SelectedItem = r.Cells["sentido"].Value?.ToString();
            cmbSetor.SelectedValue = r.Cells["id_setor"].Value;
        }
    }
}
