namespace EventoApp.Forms
{
    partial class VendaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAtualizar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.s = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.D = new System.Windows.Forms.TabPage();
            this.grpNova = new System.Windows.Forms.GroupBox();
            this.lblPart = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblPreco = new System.Windows.Forms.Label();
            this.lblValidade = new System.Windows.Forms.Label();
            this.lblMetodo = new System.Windows.Forms.Label();
            this.lblRef = new System.Windows.Forms.Label();
            this.cmbParticipante = new System.Windows.Forms.ComboBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.cmbMetodo = new System.Windows.Forms.ComboBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.dtpValidade = new System.Windows.Forms.DateTimePicker();
            this.btnRegistar = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbNovTipo = new System.Windows.Forms.ComboBox();
            this.txtNovPreco = new System.Windows.Forms.TextBox();
            this.dtpNovValidade = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbNovMetodo = new System.Windows.Forms.ComboBox();
            this.txtNovReferencia = new System.Windows.Forms.TextBox();
            this.lblNif = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblEvento = new System.Windows.Forms.Label();
            this.txtNovNif = new System.Windows.Forms.TextBox();
            this.txtNovNome = new System.Windows.Forms.TextBox();
            this.txtNovTel = new System.Windows.Forms.TextBox();
            this.cmbNovEvento = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblStand = new System.Windows.Forms.Label();
            this.lblProfissao = new System.Windows.Forms.Label();
            this.txtNovEmpresa = new System.Windows.Forms.TextBox();
            this.txtNovProfissao = new System.Windows.Forms.TextBox();
            this.cmbNovStand = new System.Windows.Forms.ComboBox();
            this.rdbNovVisitante = new System.Windows.Forms.RadioButton();
            this.rdbNovExpositor = new System.Windows.Forms.RadioButton();
            this.btnCriarERegistar = new System.Windows.Forms.Button();
            this.s.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.D.SuspendLayout();
            this.grpNova.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(994, 517);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(114, 32);
            this.btnAtualizar.TabIndex = 2;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // s
            // 
            this.s.Controls.Add(this.tabPage1);
            this.s.Controls.Add(this.D);
            this.s.Location = new System.Drawing.Point(3, 6);
            this.s.Name = "s";
            this.s.SelectedIndex = 0;
            this.s.Size = new System.Drawing.Size(1119, 513);
            this.s.TabIndex = 3;
            this.s.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.grpNova);
            this.tabPage1.Controls.Add(this.dgv);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1111, 484);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Participante Existente";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // D
            // 
            this.D.Controls.Add(this.groupBox1);
            this.D.Location = new System.Drawing.Point(4, 25);
            this.D.Name = "D";
            this.D.Padding = new System.Windows.Forms.Padding(3);
            this.D.Size = new System.Drawing.Size(1111, 484);
            this.D.TabIndex = 1;
            this.D.Text = "        Novo Participante    ";
            this.D.UseVisualStyleBackColor = true;
            // 
            // grpNova
            // 
            this.grpNova.Controls.Add(this.lblPart);
            this.grpNova.Controls.Add(this.lblTipo);
            this.grpNova.Controls.Add(this.lblPreco);
            this.grpNova.Controls.Add(this.lblValidade);
            this.grpNova.Controls.Add(this.lblMetodo);
            this.grpNova.Controls.Add(this.lblRef);
            this.grpNova.Controls.Add(this.cmbParticipante);
            this.grpNova.Controls.Add(this.cmbTipo);
            this.grpNova.Controls.Add(this.cmbMetodo);
            this.grpNova.Controls.Add(this.txtPreco);
            this.grpNova.Controls.Add(this.txtReferencia);
            this.grpNova.Controls.Add(this.dtpValidade);
            this.grpNova.Controls.Add(this.btnRegistar);
            this.grpNova.Location = new System.Drawing.Point(7, 11);
            this.grpNova.Name = "grpNova";
            this.grpNova.Size = new System.Drawing.Size(1097, 195);
            this.grpNova.TabIndex = 2;
            this.grpNova.TabStop = false;
            this.grpNova.Text = "Nova Venda";
            // 
            // lblPart
            // 
            this.lblPart.Location = new System.Drawing.Point(17, 32);
            this.lblPart.Name = "lblPart";
            this.lblPart.Size = new System.Drawing.Size(114, 25);
            this.lblPart.TabIndex = 0;
            this.lblPart.Text = "Participante:";
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(17, 64);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(114, 25);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "Tipo Acesso:";
            // 
            // lblPreco
            // 
            this.lblPreco.Location = new System.Drawing.Point(17, 96);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(114, 25);
            this.lblPreco.TabIndex = 2;
            this.lblPreco.Text = "Preço (€):";
            // 
            // lblValidade
            // 
            this.lblValidade.Location = new System.Drawing.Point(17, 128);
            this.lblValidade.Name = "lblValidade";
            this.lblValidade.Size = new System.Drawing.Size(114, 25);
            this.lblValidade.TabIndex = 3;
            this.lblValidade.Text = "Validade:";
            // 
            // lblMetodo
            // 
            this.lblMetodo.Location = new System.Drawing.Point(514, 32);
            this.lblMetodo.Name = "lblMetodo";
            this.lblMetodo.Size = new System.Drawing.Size(114, 25);
            this.lblMetodo.TabIndex = 4;
            this.lblMetodo.Text = "Método pgto:";
            // 
            // lblRef
            // 
            this.lblRef.Location = new System.Drawing.Point(514, 64);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(114, 25);
            this.lblRef.TabIndex = 5;
            this.lblRef.Text = "Referência:";
            // 
            // cmbParticipante
            // 
            this.cmbParticipante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParticipante.Location = new System.Drawing.Point(137, 29);
            this.cmbParticipante.Name = "cmbParticipante";
            this.cmbParticipante.Size = new System.Drawing.Size(342, 24);
            this.cmbParticipante.TabIndex = 6;
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Location = new System.Drawing.Point(137, 61);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(228, 24);
            this.cmbTipo.TabIndex = 7;
            // 
            // cmbMetodo
            // 
            this.cmbMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodo.Location = new System.Drawing.Point(634, 29);
            this.cmbMetodo.Name = "cmbMetodo";
            this.cmbMetodo.Size = new System.Drawing.Size(228, 24);
            this.cmbMetodo.TabIndex = 8;
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(137, 93);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(114, 22);
            this.txtPreco.TabIndex = 9;
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(634, 61);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(342, 22);
            this.txtReferencia.TabIndex = 10;
            // 
            // dtpValidade
            // 
            this.dtpValidade.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpValidade.Location = new System.Drawing.Point(137, 125);
            this.dtpValidade.Name = "dtpValidade";
            this.dtpValidade.Size = new System.Drawing.Size(228, 22);
            this.dtpValidade.TabIndex = 11;
            // 
            // btnRegistar
            // 
            this.btnRegistar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistar.Location = new System.Drawing.Point(880, 139);
            this.btnRegistar.Name = "btnRegistar";
            this.btnRegistar.Size = new System.Drawing.Size(194, 43);
            this.btnRegistar.TabIndex = 12;
            this.btnRegistar.Text = "Registar Venda";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeight = 29;
            this.dgv.Location = new System.Drawing.Point(7, 233);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1097, 259);
            this.dgv.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCriarERegistar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblEmpresa);
            this.groupBox1.Controls.Add(this.lblStand);
            this.groupBox1.Controls.Add(this.lblProfissao);
            this.groupBox1.Controls.Add(this.txtNovEmpresa);
            this.groupBox1.Controls.Add(this.txtNovProfissao);
            this.groupBox1.Controls.Add(this.cmbNovStand);
            this.groupBox1.Controls.Add(this.rdbNovVisitante);
            this.groupBox1.Controls.Add(this.rdbNovExpositor);
            this.groupBox1.Controls.Add(this.lblNif);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblTel);
            this.groupBox1.Controls.Add(this.cmbNovMetodo);
            this.groupBox1.Controls.Add(this.lblEvento);
            this.groupBox1.Controls.Add(this.txtNovReferencia);
            this.groupBox1.Controls.Add(this.txtNovNif);
            this.groupBox1.Controls.Add(this.txtNovNome);
            this.groupBox1.Controls.Add(this.txtNovTel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbNovEvento);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbNovTipo);
            this.groupBox1.Controls.Add(this.txtNovPreco);
            this.groupBox1.Controls.Add(this.dtpNovValidade);
            this.groupBox1.Location = new System.Drawing.Point(21, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1062, 293);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Novo Participante e Nova Venda";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(507, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Tipo Acesso:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(507, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "Preço (€):";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(507, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "Validade:";
            // 
            // cmbNovTipo
            // 
            this.cmbNovTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNovTipo.Location = new System.Drawing.Point(627, 19);
            this.cmbNovTipo.Name = "cmbNovTipo";
            this.cmbNovTipo.Size = new System.Drawing.Size(228, 24);
            this.cmbNovTipo.TabIndex = 17;
            // 
            // txtNovPreco
            // 
            this.txtNovPreco.Location = new System.Drawing.Point(627, 51);
            this.txtNovPreco.Name = "txtNovPreco";
            this.txtNovPreco.Size = new System.Drawing.Size(114, 22);
            this.txtNovPreco.TabIndex = 18;
            // 
            // dtpNovValidade
            // 
            this.dtpNovValidade.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNovValidade.Location = new System.Drawing.Point(627, 83);
            this.dtpNovValidade.Name = "dtpNovValidade";
            this.dtpNovValidade.Size = new System.Drawing.Size(228, 22);
            this.dtpNovValidade.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(508, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 25);
            this.label10.TabIndex = 20;
            this.label10.Text = "Método pgto:";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(508, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 25);
            this.label11.TabIndex = 21;
            this.label11.Text = "Referência:";
            // 
            // cmbNovMetodo
            // 
            this.cmbNovMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNovMetodo.Location = new System.Drawing.Point(628, 123);
            this.cmbNovMetodo.Name = "cmbNovMetodo";
            this.cmbNovMetodo.Size = new System.Drawing.Size(228, 24);
            this.cmbNovMetodo.TabIndex = 22;
            // 
            // txtNovReferencia
            // 
            this.txtNovReferencia.Location = new System.Drawing.Point(628, 155);
            this.txtNovReferencia.Name = "txtNovReferencia";
            this.txtNovReferencia.Size = new System.Drawing.Size(342, 22);
            this.txtNovReferencia.TabIndex = 23;
            // 
            // lblNif
            // 
            this.lblNif.Location = new System.Drawing.Point(18, 26);
            this.lblNif.Name = "lblNif";
            this.lblNif.Size = new System.Drawing.Size(103, 25);
            this.lblNif.TabIndex = 17;
            this.lblNif.Text = "NIF:";
            // 
            // lblNome
            // 
            this.lblNome.Location = new System.Drawing.Point(18, 58);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(103, 25);
            this.lblNome.TabIndex = 18;
            this.lblNome.Text = "Nome:";
            // 
            // lblTel
            // 
            this.lblTel.Location = new System.Drawing.Point(18, 90);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(103, 25);
            this.lblTel.TabIndex = 19;
            this.lblTel.Text = "Telemóvel:";
            // 
            // lblEvento
            // 
            this.lblEvento.Location = new System.Drawing.Point(18, 122);
            this.lblEvento.Name = "lblEvento";
            this.lblEvento.Size = new System.Drawing.Size(103, 25);
            this.lblEvento.TabIndex = 20;
            this.lblEvento.Text = "Evento:";
            // 
            // txtNovNif
            // 
            this.txtNovNif.Location = new System.Drawing.Point(130, 22);
            this.txtNovNif.Name = "txtNovNif";
            this.txtNovNif.Size = new System.Drawing.Size(171, 22);
            this.txtNovNif.TabIndex = 21;
            // 
            // txtNovNome
            // 
            this.txtNovNome.Location = new System.Drawing.Point(130, 54);
            this.txtNovNome.Name = "txtNovNome";
            this.txtNovNome.Size = new System.Drawing.Size(365, 22);
            this.txtNovNome.TabIndex = 22;
            // 
            // txtNovTel
            // 
            this.txtNovTel.Location = new System.Drawing.Point(130, 86);
            this.txtNovTel.Name = "txtNovTel";
            this.txtNovTel.Size = new System.Drawing.Size(171, 22);
            this.txtNovTel.TabIndex = 23;
            // 
            // cmbNovEvento
            // 
            this.cmbNovEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNovEvento.Location = new System.Drawing.Point(130, 118);
            this.cmbNovEvento.Name = "cmbNovEvento";
            this.cmbNovEvento.Size = new System.Drawing.Size(285, 24);
            this.cmbNovEvento.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(18, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tipo:";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Location = new System.Drawing.Point(18, 191);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(91, 25);
            this.lblEmpresa.TabIndex = 26;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // lblStand
            // 
            this.lblStand.Location = new System.Drawing.Point(18, 223);
            this.lblStand.Name = "lblStand";
            this.lblStand.Size = new System.Drawing.Size(91, 25);
            this.lblStand.TabIndex = 27;
            this.lblStand.Text = "Stand:";
            // 
            // lblProfissao
            // 
            this.lblProfissao.Location = new System.Drawing.Point(18, 255);
            this.lblProfissao.Name = "lblProfissao";
            this.lblProfissao.Size = new System.Drawing.Size(91, 25);
            this.lblProfissao.TabIndex = 28;
            this.lblProfissao.Text = "Profissão:";
            // 
            // txtNovEmpresa
            // 
            this.txtNovEmpresa.Location = new System.Drawing.Point(130, 188);
            this.txtNovEmpresa.Name = "txtNovEmpresa";
            this.txtNovEmpresa.Size = new System.Drawing.Size(285, 22);
            this.txtNovEmpresa.TabIndex = 29;
            // 
            // txtNovProfissao
            // 
            this.txtNovProfissao.Location = new System.Drawing.Point(130, 252);
            this.txtNovProfissao.Name = "txtNovProfissao";
            this.txtNovProfissao.Size = new System.Drawing.Size(285, 22);
            this.txtNovProfissao.TabIndex = 30;
            // 
            // cmbNovStand
            // 
            this.cmbNovStand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNovStand.Location = new System.Drawing.Point(130, 220);
            this.cmbNovStand.Name = "cmbNovStand";
            this.cmbNovStand.Size = new System.Drawing.Size(171, 24);
            this.cmbNovStand.TabIndex = 31;
            // 
            // rdbNovVisitante
            // 
            this.rdbNovVisitante.Location = new System.Drawing.Point(130, 158);
            this.rdbNovVisitante.Name = "rdbNovVisitante";
            this.rdbNovVisitante.Size = new System.Drawing.Size(114, 25);
            this.rdbNovVisitante.TabIndex = 32;
            this.rdbNovVisitante.Text = "Visitante";
            // 
            // rdbNovExpositor
            // 
            this.rdbNovExpositor.Location = new System.Drawing.Point(244, 158);
            this.rdbNovExpositor.Name = "rdbNovExpositor";
            this.rdbNovExpositor.Size = new System.Drawing.Size(114, 25);
            this.rdbNovExpositor.TabIndex = 33;
            this.rdbNovExpositor.Text = "Expositor";
            // 
            // btnCriarERegistar
            // 
            this.btnCriarERegistar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCriarERegistar.Location = new System.Drawing.Point(627, 222);
            this.btnCriarERegistar.Name = "btnCriarERegistar";
            this.btnCriarERegistar.Size = new System.Drawing.Size(342, 43);
            this.btnCriarERegistar.TabIndex = 34;
            this.btnCriarERegistar.Text = "Criar Participante e Registar Venda";
            this.btnCriarERegistar.Click += new System.EventHandler(this.button1_Click);
            // 
            // VendaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 560);
            this.Controls.Add(this.s);
            this.Controls.Add(this.btnAtualizar);
            this.Name = "VendaForm";
            this.Text = "Vendas";
            this.s.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.D.ResumeLayout(false);
            this.grpNova.ResumeLayout(false);
            this.grpNova.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl s;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage D;
        private System.Windows.Forms.GroupBox grpNova;
        private System.Windows.Forms.Label lblPart;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Label lblValidade;
        private System.Windows.Forms.Label lblMetodo;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.ComboBox cmbParticipante;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.ComboBox cmbMetodo;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.DateTimePicker dtpValidade;
        private System.Windows.Forms.Button btnRegistar;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbNovTipo;
        private System.Windows.Forms.TextBox txtNovPreco;
        private System.Windows.Forms.DateTimePicker dtpNovValidade;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbNovMetodo;
        private System.Windows.Forms.TextBox txtNovReferencia;
        private System.Windows.Forms.Label lblNif;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblEvento;
        private System.Windows.Forms.TextBox txtNovNif;
        private System.Windows.Forms.TextBox txtNovNome;
        private System.Windows.Forms.TextBox txtNovTel;
        private System.Windows.Forms.ComboBox cmbNovEvento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblStand;
        private System.Windows.Forms.Label lblProfissao;
        private System.Windows.Forms.TextBox txtNovEmpresa;
        private System.Windows.Forms.TextBox txtNovProfissao;
        private System.Windows.Forms.ComboBox cmbNovStand;
        private System.Windows.Forms.RadioButton rdbNovVisitante;
        private System.Windows.Forms.RadioButton rdbNovExpositor;
        private System.Windows.Forms.Button btnCriarERegistar;
    }
}