namespace EventoApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuCadastros;
        private System.Windows.Forms.ToolStripMenuItem menuEventos;
        private System.Windows.Forms.ToolStripMenuItem menuParticipantes;
        private System.Windows.Forms.ToolStripMenuItem menuSetores;
        private System.Windows.Forms.ToolStripMenuItem menuStands;
        private System.Windows.Forms.ToolStripMenuItem menuPontosAcesso;
        private System.Windows.Forms.ToolStripMenuItem menuTiposAcesso;
        private System.Windows.Forms.ToolStripMenuItem menuTokens;
        private System.Windows.Forms.ToolStripMenuItem menuOperacoes;
        private System.Windows.Forms.ToolStripMenuItem menuVendas;
        private System.Windows.Forms.ToolStripMenuItem menuValidacao;
        private System.Windows.Forms.ToolStripMenuItem menuFicheiro;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblUtilizadorStatus;
        private System.Windows.Forms.Label lblUtilizador;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFicheiro = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEventos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuParticipantes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStands = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPontosAcesso = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTiposAcesso = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTokens = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOperacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuValidacao = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblUtilizadorStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUtilizador = new System.Windows.Forms.Label();
            this.menuDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFicheiro,
            this.menuCadastros,
            this.menuOperacoes,
            this.menuDashboard});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1029, 28);
            this.menuStrip.TabIndex = 2;
            // 
            // menuFicheiro
            // 
            this.menuFicheiro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSair});
            this.menuFicheiro.Name = "menuFicheiro";
            this.menuFicheiro.Size = new System.Drawing.Size(75, 24);
            this.menuFicheiro.Text = "&Ficheiro";
            // 
            // menuSair
            // 
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(117, 26);
            this.menuSair.Text = "Sair";
            this.menuSair.Click += new System.EventHandler(this.menuSair_Click);
            // 
            // menuCadastros
            // 
            this.menuCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEventos,
            this.menuParticipantes,
            this.menuSetores,
            this.menuStands,
            this.menuPontosAcesso,
            this.menuTiposAcesso,
            this.menuTokens});
            this.menuCadastros.Name = "menuCadastros";
            this.menuCadastros.Size = new System.Drawing.Size(88, 24);
            this.menuCadastros.Text = "&Cadastros";
            // 
            // menuEventos
            // 
            this.menuEventos.Name = "menuEventos";
            this.menuEventos.Size = new System.Drawing.Size(323, 26);
            this.menuEventos.Text = "Eventos";
            this.menuEventos.Click += new System.EventHandler(this.menuEventos_Click);
            // 
            // menuParticipantes
            // 
            this.menuParticipantes.Name = "menuParticipantes";
            this.menuParticipantes.Size = new System.Drawing.Size(323, 26);
            this.menuParticipantes.Text = "Participantes (Expositor / Visitante)";
            this.menuParticipantes.Click += new System.EventHandler(this.menuParticipantes_Click);
            // 
            // menuSetores
            // 
            this.menuSetores.Name = "menuSetores";
            this.menuSetores.Size = new System.Drawing.Size(323, 26);
            this.menuSetores.Text = "Setores";
            this.menuSetores.Click += new System.EventHandler(this.menuSetores_Click);
            // 
            // menuStands
            // 
            this.menuStands.Name = "menuStands";
            this.menuStands.Size = new System.Drawing.Size(323, 26);
            this.menuStands.Text = "Stands";
            this.menuStands.Click += new System.EventHandler(this.menuStands_Click);
            // 
            // menuPontosAcesso
            // 
            this.menuPontosAcesso.Name = "menuPontosAcesso";
            this.menuPontosAcesso.Size = new System.Drawing.Size(323, 26);
            this.menuPontosAcesso.Text = "Pontos de Acesso";
            this.menuPontosAcesso.Click += new System.EventHandler(this.menuPontosAcesso_Click);
            // 
            // menuTiposAcesso
            // 
            this.menuTiposAcesso.Name = "menuTiposAcesso";
            this.menuTiposAcesso.Size = new System.Drawing.Size(323, 26);
            this.menuTiposAcesso.Text = "Tipos de Acesso";
            this.menuTiposAcesso.Click += new System.EventHandler(this.menuTiposAcesso_Click);
            // 
            // menuTokens
            // 
            this.menuTokens.Name = "menuTokens";
            this.menuTokens.Size = new System.Drawing.Size(323, 26);
            this.menuTokens.Text = "Tokens";
            this.menuTokens.Click += new System.EventHandler(this.menuTokens_Click);
            // 
            // menuOperacoes
            // 
            this.menuOperacoes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuVendas,
            this.menuValidacao});
            this.menuOperacoes.Name = "menuOperacoes";
            this.menuOperacoes.Size = new System.Drawing.Size(94, 24);
            this.menuOperacoes.Text = "&Operações";
            // 
            // menuVendas
            // 
            this.menuVendas.Name = "menuVendas";
            this.menuVendas.Size = new System.Drawing.Size(228, 26);
            this.menuVendas.Text = "Venda de Ingressos";
            this.menuVendas.Click += new System.EventHandler(this.menuVendas_Click);
            // 
            // menuValidacao
            // 
            this.menuValidacao.Name = "menuValidacao";
            this.menuValidacao.Size = new System.Drawing.Size(228, 26);
            this.menuValidacao.Text = "Validação de Acesso";
            this.menuValidacao.Click += new System.EventHandler(this.menuValidacao_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUtilizadorStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 614);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(1029, 26);
            this.statusStrip.TabIndex = 1;
            // 
            // lblUtilizadorStatus
            // 
            this.lblUtilizadorStatus.Name = "lblUtilizadorStatus";
            this.lblUtilizadorStatus.Size = new System.Drawing.Size(53, 20);
            this.lblUtilizadorStatus.Text = "Pronto";
            // 
            // lblUtilizador
            // 
            this.lblUtilizador.AutoSize = true;
            this.lblUtilizador.Location = new System.Drawing.Point(857, 5);
            this.lblUtilizador.Name = "lblUtilizador";
            this.lblUtilizador.Size = new System.Drawing.Size(57, 16);
            this.lblUtilizador.TabIndex = 0;
            this.lblUtilizador.Text = "Sessão:";
            // 
            // menuDashboard
            // 
            this.menuDashboard.Name = "menuDashboard";
            this.menuDashboard.Size = new System.Drawing.Size(96, 24);
            this.menuDashboard.Text = "Dashboard";
            this.menuDashboard.Click += new System.EventHandler(this.menuDashboard_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 640);
            this.Controls.Add(this.lblUtilizador);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventoApp - Gestão de Eventos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem menuDashboard;
    }
}
