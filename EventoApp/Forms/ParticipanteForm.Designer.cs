namespace IngressosFM.Forms
{
    partial class ParticipanteForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblId, lblNif, lblNome, lblTel, lblEvento, lblTipo, lblEmpresa, lblStand, lblProfissao;
        private System.Windows.Forms.TextBox txtId, txtNif, txtNome, txtTel, txtEmpresa, txtProfissao;
        private System.Windows.Forms.ComboBox cmbEvento, cmbStand;
        private System.Windows.Forms.RadioButton rdbExpositor, rdbVisitante;
        private System.Windows.Forms.Button btnNovo, btnGuardar, btnEliminar, btnAtualizar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lblId = new System.Windows.Forms.Label();
            this.lblNif = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblEvento = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblStand = new System.Windows.Forms.Label();
            this.lblProfissao = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNif = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.txtProfissao = new System.Windows.Forms.TextBox();
            this.cmbEvento = new System.Windows.Forms.ComboBox();
            this.cmbStand = new System.Windows.Forms.ComboBox();
            this.rdbExpositor = new System.Windows.Forms.RadioButton();
            this.rdbVisitante = new System.Windows.Forms.RadioButton();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();

            this.dgv.Location = new System.Drawing.Point(12, 12);
            this.dgv.Size = new System.Drawing.Size(960, 250);
            this.dgv.ReadOnly = true; this.dgv.AllowUserToAddRows = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.MultiSelect = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);

            // Coluna esquerda
            this.lblId.Location = new System.Drawing.Point(12, 280); this.lblId.Text = "ID:"; this.lblId.Size = new System.Drawing.Size(90, 23);
            this.lblNif.Location = new System.Drawing.Point(12, 310); this.lblNif.Text = "NIF:"; this.lblNif.Size = new System.Drawing.Size(90, 23);
            this.lblNome.Location = new System.Drawing.Point(12, 340); this.lblNome.Text = "Nome:"; this.lblNome.Size = new System.Drawing.Size(90, 23);
            this.lblTel.Location = new System.Drawing.Point(12, 370); this.lblTel.Text = "Telemóvel:"; this.lblTel.Size = new System.Drawing.Size(90, 23);
            this.lblEvento.Location = new System.Drawing.Point(12, 400); this.lblEvento.Text = "Evento:"; this.lblEvento.Size = new System.Drawing.Size(90, 23);

            this.txtId.Location = new System.Drawing.Point(110, 277); this.txtId.Size = new System.Drawing.Size(120, 23); this.txtId.ReadOnly = true;
            this.txtNif.Location = new System.Drawing.Point(110, 307); this.txtNif.Size = new System.Drawing.Size(150, 23);
            this.txtNome.Location = new System.Drawing.Point(110, 337); this.txtNome.Size = new System.Drawing.Size(320, 23);
            this.txtTel.Location = new System.Drawing.Point(110, 367); this.txtTel.Size = new System.Drawing.Size(150, 23);
            this.cmbEvento.Location = new System.Drawing.Point(110, 397); this.cmbEvento.Size = new System.Drawing.Size(250, 23);
            this.cmbEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Coluna direita - tipo
            this.lblTipo.Location = new System.Drawing.Point(470, 280); this.lblTipo.Text = "Tipo:"; this.lblTipo.Size = new System.Drawing.Size(80, 23);
            this.rdbVisitante.Location = new System.Drawing.Point(560, 278); this.rdbVisitante.Text = "Visitante"; this.rdbVisitante.Size = new System.Drawing.Size(100, 23);
            this.rdbVisitante.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            this.rdbExpositor.Location = new System.Drawing.Point(660, 278); this.rdbExpositor.Text = "Expositor"; this.rdbExpositor.Size = new System.Drawing.Size(100, 23);
            this.rdbExpositor.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);

            this.lblEmpresa.Location = new System.Drawing.Point(470, 310); this.lblEmpresa.Text = "Empresa:"; this.lblEmpresa.Size = new System.Drawing.Size(80, 23);
            this.txtEmpresa.Location = new System.Drawing.Point(560, 307); this.txtEmpresa.Size = new System.Drawing.Size(250, 23);
            this.lblStand.Location = new System.Drawing.Point(470, 340); this.lblStand.Text = "Stand:"; this.lblStand.Size = new System.Drawing.Size(80, 23);
            this.cmbStand.Location = new System.Drawing.Point(560, 337); this.cmbStand.Size = new System.Drawing.Size(150, 23);
            this.cmbStand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lblProfissao.Location = new System.Drawing.Point(470, 370); this.lblProfissao.Text = "Profissão:"; this.lblProfissao.Size = new System.Drawing.Size(80, 23);
            this.txtProfissao.Location = new System.Drawing.Point(560, 367); this.txtProfissao.Size = new System.Drawing.Size(250, 23);

            this.btnNovo.Location = new System.Drawing.Point(770, 397); this.btnNovo.Size = new System.Drawing.Size(95, 30); this.btnNovo.Text = "Novo";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnGuardar.Location = new System.Drawing.Point(875, 397); this.btnGuardar.Size = new System.Drawing.Size(95, 30); this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnEliminar.Location = new System.Drawing.Point(770, 432); this.btnEliminar.Size = new System.Drawing.Size(95, 30); this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnAtualizar.Location = new System.Drawing.Point(875, 432); this.btnAtualizar.Size = new System.Drawing.Size(95, 30); this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 480);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblId); this.Controls.Add(this.lblNif); this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblTel); this.Controls.Add(this.lblEvento); this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblEmpresa); this.Controls.Add(this.lblStand); this.Controls.Add(this.lblProfissao);
            this.Controls.Add(this.txtId); this.Controls.Add(this.txtNif); this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtTel); this.Controls.Add(this.txtEmpresa); this.Controls.Add(this.txtProfissao);
            this.Controls.Add(this.cmbEvento); this.Controls.Add(this.cmbStand);
            this.Controls.Add(this.rdbVisitante); this.Controls.Add(this.rdbExpositor);
            this.Controls.Add(this.btnNovo); this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar); this.Controls.Add(this.btnAtualizar);
            this.Text = "Gestão de Participantes";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
