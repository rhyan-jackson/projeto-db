using System;
using System.Windows.Forms;

namespace EventoApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly string _utilizador;

        public MainForm(string utilizador)
        {
            InitializeComponent();
            _utilizador = utilizador;
            lblUtilizador.Text = "Sessão: " + utilizador;
        }

        // Abre cada form como filho dentro do MDI parent
        private void Abrir(Form f)
        {
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        // ===== EVENTOS DO MENU =====
        private void menuEventos_Click(object sender, EventArgs e) => Abrir(new EventoForm());
        private void menuParticipantes_Click(object sender, EventArgs e) => Abrir(new ParticipanteForm());
        private void menuSetores_Click(object sender, EventArgs e) => Abrir(new SetorForm());
        private void menuStands_Click(object sender, EventArgs e) => Abrir(new StandForm());
        private void menuPontosAcesso_Click(object sender, EventArgs e) => Abrir(new PontoAcessoForm());
        private void menuTiposAcesso_Click(object sender, EventArgs e) => Abrir(new TipoAcessoForm());
        private void menuTokens_Click(object sender, EventArgs e) => Abrir(new TokenForm());
        private void menuVendas_Click(object sender, EventArgs e) => Abrir(new VendaForm(_utilizador));
        private void menuValidacao_Click(object sender, EventArgs e) => Abrir(new ValidacaoForm());
        private void menuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuDashboard_Click_1(object sender, EventArgs e)
        {
            Abrir(new DashboardForm());
        }
    }
}
