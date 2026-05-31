using System;
using System.Globalization;
using System.Windows.Forms;
using EventoApp.Database;

namespace EventoApp.Forms
{
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
            CarregarNovEventos();
            CarregarNovStands();
            CarregarNovTiposAcesso();
            CarregarNovMetodos();
        }

        // ── 1ª aba: Participante existente ──────────────────────────────

        private void CarregarParticipantes()
        {
            var t = DbHelper.ExecuteQuery(
                "SELECT id_participante, nome_completo FROM dbo.Participante ORDER BY nome_completo");
            cmbParticipante.DisplayMember = "nome_completo";
            cmbParticipante.ValueMember   = "id_participante";
            cmbParticipante.DataSource    = t;
        }

        private void CarregarTiposAcesso()
        {
            var t = DbHelper.ExecuteQuery(
                "SELECT id_tipo, nome_perfil FROM dbo.Tipo_de_Acesso ORDER BY nome_perfil");
            cmbTipo.DisplayMember = "nome_perfil";
            cmbTipo.ValueMember   = "id_tipo";
            cmbTipo.DataSource    = t;
        }

        private void CarregarMetodos()
        {
            cmbMetodo.Items.AddRange(new object[]
                { "Multibanco", "MBWay", "Cartão de Crédito", "Numerário", "Transferência" });
            cmbMetodo.SelectedIndex = 0;
        }

        private void CarregarVendas()
        {
            dgv.DataSource = DbHelper.ExecuteQuery("SELECT * FROM dbo.vw_Vendas");
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

            try
            {
                var dt = DbHelper.ExecuteQuery(
                    "EXEC dbo.sp_RegistarVenda @email, @tipo, @preco, @validade, @part, @metodo, @ref",
                    DbHelper.P("@email",    _utilizadorEmail),
                    DbHelper.P("@tipo",     cmbTipo.SelectedValue),
                    DbHelper.P("@preco",    preco),
                    DbHelper.P("@validade", dtpValidade.Value.Date),
                    DbHelper.P("@part",     cmbParticipante.SelectedValue),
                    DbHelper.P("@metodo",   cmbMetodo.SelectedItem),
                    DbHelper.P("@ref",      string.IsNullOrWhiteSpace(txtReferencia.Text)
                                            ? (object)DBNull.Value : txtReferencia.Text.Trim()));

                var idVenda = dt.Rows[0]["id_venda"];
                var qr      = dt.Rows[0]["codigo_qr"];
                MessageBox.Show($"Venda #{idVenda} registada.\nToken QR: {qr}",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarVendas();
                txtPreco.Clear();
                txtReferencia.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro a registar venda:\n" + ex.Message);
            }
        }

        // ── 2ª aba: Novo participante ────────────────────────────────────

        private void CarregarNovEventos()
        {
            var t = DbHelper.ExecuteQuery("SELECT id_evento, nome FROM dbo.Evento ORDER BY nome");
            cmbNovEvento.DisplayMember = "nome";
            cmbNovEvento.ValueMember   = "id_evento";
            cmbNovEvento.DataSource    = t;
        }

        private void CarregarNovStands()
        {
            var t = DbHelper.ExecuteQuery("SELECT id_stand FROM dbo.Stand ORDER BY id_stand");
            cmbNovStand.DisplayMember = "id_stand";
            cmbNovStand.ValueMember   = "id_stand";
            cmbNovStand.DataSource    = t;
        }

        private void CarregarNovTiposAcesso()
        {
            var t = DbHelper.ExecuteQuery(
                "SELECT id_tipo, nome_perfil FROM dbo.Tipo_de_Acesso ORDER BY nome_perfil");
            cmbNovTipo.DisplayMember = "nome_perfil";
            cmbNovTipo.ValueMember   = "id_tipo";
            cmbNovTipo.DataSource    = t;
        }

        private void CarregarNovMetodos()
        {
            cmbNovMetodo.Items.AddRange(new object[]
                { "Multibanco", "MBWay", "Cartão de Crédito", "Numerário", "Transferência" });
            cmbNovMetodo.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNovNif.Text))
                { MessageBox.Show("NIF obrigatório.");  return; }
            if (string.IsNullOrWhiteSpace(txtNovNome.Text))
                { MessageBox.Show("Nome obrigatório."); return; }
            if (cmbNovEvento.SelectedValue == null)
                { MessageBox.Show("Escolhe evento.");   return; }
            if (cmbNovTipo.SelectedValue == null)
                { MessageBox.Show("Escolhe tipo de acesso."); return; }
            if (!decimal.TryParse(txtNovPreco.Text.Replace(',', '.'),
                NumberStyles.Any, CultureInfo.InvariantCulture, out decimal preco) || preco <= 0)
                { MessageBox.Show("Preço inválido."); return; }
            if (cmbNovMetodo.SelectedItem == null)
                { MessageBox.Show("Escolhe método de pagamento."); return; }

            try
            {
                int idPart = DbHelper.NextId("Participante", "id_participante");

                var dt = DbHelper.ExecuteQuery(
                    "EXEC dbo.sp_CriarParticipanteEVenda @id_part, @nif, @nome, @tel, @id_evento, @tipo, @emp, @stand, @prof, @email, @id_tipo_acesso, @preco, @validade, @metodo, @ref",
                    DbHelper.P("@id_part",        idPart),
                    DbHelper.P("@nif",            txtNovNif.Text.Trim()),
                    DbHelper.P("@nome",           txtNovNome.Text.Trim()),
                    DbHelper.P("@tel",            string.IsNullOrWhiteSpace(txtNovTel.Text) ? (object)DBNull.Value : txtNovTel.Text.Trim()),
                    DbHelper.P("@id_evento",      cmbNovEvento.SelectedValue),
                    DbHelper.P("@tipo",           rdbNovExpositor.Checked ? "Expositor" : "Visitante"),
                    DbHelper.P("@emp",            string.IsNullOrWhiteSpace(txtNovEmpresa.Text) ? (object)DBNull.Value : txtNovEmpresa.Text.Trim()),
                    DbHelper.P("@stand",          cmbNovStand.SelectedValue ?? (object)DBNull.Value),
                    DbHelper.P("@prof",           string.IsNullOrWhiteSpace(txtNovProfissao.Text) ? (object)DBNull.Value : txtNovProfissao.Text.Trim()),
                    DbHelper.P("@email",          _utilizadorEmail),
                    DbHelper.P("@id_tipo_acesso", cmbNovTipo.SelectedValue),
                    DbHelper.P("@preco",          preco),
                    DbHelper.P("@validade",       dtpNovValidade.Value.Date),
                    DbHelper.P("@metodo",         cmbNovMetodo.SelectedItem),
                    DbHelper.P("@ref",            string.IsNullOrWhiteSpace(txtNovReferencia.Text) ? (object)DBNull.Value : txtNovReferencia.Text.Trim()));

                var idVenda = dt.Rows[0]["id_venda"];
                var qr      = dt.Rows[0]["codigo_qr"];
                MessageBox.Show($"Participante criado e venda #{idVenda} registada.\nToken QR: {qr}",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarParticipantes();
                CarregarVendas();
                txtNovNif.Clear(); txtNovNome.Clear(); txtNovTel.Clear();
                txtNovEmpresa.Clear(); txtNovProfissao.Clear();
                txtNovPreco.Clear(); txtNovReferencia.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e) => CarregarVendas();
    }
}
