namespace EventoApp.Forms
{
    partial class VendaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpNova;
        private System.Windows.Forms.Label lblPart, lblTipo, lblPreco, lblValidade, lblMetodo, lblRef;
        private System.Windows.Forms.ComboBox cmbParticipante, cmbTipo, cmbMetodo;
        private System.Windows.Forms.TextBox txtPreco, txtReferencia;
        private System.Windows.Forms.DateTimePicker dtpValidade;
        private System.Windows.Forms.Button btnRegistar;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnAtualizar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
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
            this.btnAtualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.grpNova.SuspendLayout();
            this.SuspendLayout();

            // GroupBox Nova Venda
            this.grpNova.Location = new System.Drawing.Point(12, 12);
            this.grpNova.Size = new System.Drawing.Size(960, 200);
            this.grpNova.Text = "Nova Venda";

            this.lblPart.Location = new System.Drawing.Point(15, 30); this.lblPart.Text = "Participante:"; this.lblPart.Size = new System.Drawing.Size(100, 23);
            this.cmbParticipante.Location = new System.Drawing.Point(120, 27); this.cmbParticipante.Size = new System.Drawing.Size(300, 23);
            this.cmbParticipante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblTipo.Location = new System.Drawing.Point(15, 60); this.lblTipo.Text = "Tipo Acesso:"; this.lblTipo.Size = new System.Drawing.Size(100, 23);
            this.cmbTipo.Location = new System.Drawing.Point(120, 57); this.cmbTipo.Size = new System.Drawing.Size(200, 23);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblPreco.Location = new System.Drawing.Point(15, 90); this.lblPreco.Text = "Preço (€):"; this.lblPreco.Size = new System.Drawing.Size(100, 23);
            this.txtPreco.Location = new System.Drawing.Point(120, 87); this.txtPreco.Size = new System.Drawing.Size(100, 23);

            this.lblValidade.Location = new System.Drawing.Point(15, 120); this.lblValidade.Text = "Validade:"; this.lblValidade.Size = new System.Drawing.Size(100, 23);
            this.dtpValidade.Location = new System.Drawing.Point(120, 117); this.dtpValidade.Size = new System.Drawing.Size(200, 23);
            this.dtpValidade.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblMetodo.Location = new System.Drawing.Point(450, 30); this.lblMetodo.Text = "Método pgto:"; this.lblMetodo.Size = new System.Drawing.Size(100, 23);
            this.cmbMetodo.Location = new System.Drawing.Point(555, 27); this.cmbMetodo.Size = new System.Drawing.Size(200, 23);
            this.cmbMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblRef.Location = new System.Drawing.Point(450, 60); this.lblRef.Text = "Referência:"; this.lblRef.Size = new System.Drawing.Size(100, 23);
            this.txtReferencia.Location = new System.Drawing.Point(555, 57); this.txtReferencia.Size = new System.Drawing.Size(300, 23);

            this.btnRegistar.Location = new System.Drawing.Point(770, 130); this.btnRegistar.Size = new System.Drawing.Size(170, 40);
            this.btnRegistar.Text = "Registar Venda";
            this.btnRegistar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistar.Click += new System.EventHandler(this.btnRegistar_Click);

            this.grpNova.Controls.Add(this.lblPart); this.grpNova.Controls.Add(this.lblTipo);
            this.grpNova.Controls.Add(this.lblPreco); this.grpNova.Controls.Add(this.lblValidade);
            this.grpNova.Controls.Add(this.lblMetodo); this.grpNova.Controls.Add(this.lblRef);
            this.grpNova.Controls.Add(this.cmbParticipante); this.grpNova.Controls.Add(this.cmbTipo);
            this.grpNova.Controls.Add(this.cmbMetodo); this.grpNova.Controls.Add(this.txtPreco);
            this.grpNova.Controls.Add(this.txtReferencia); this.grpNova.Controls.Add(this.dtpValidade);
            this.grpNova.Controls.Add(this.btnRegistar);

            // DataGridView vendas
            this.dgv.Location = new System.Drawing.Point(12, 220);
            this.dgv.Size = new System.Drawing.Size(960, 260);
            this.dgv.ReadOnly = true; this.dgv.AllowUserToAddRows = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.btnAtualizar.Location = new System.Drawing.Point(870, 485); this.btnAtualizar.Size = new System.Drawing.Size(100, 30);
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 525);
            this.Controls.Add(this.grpNova);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnAtualizar);
            this.Text = "Vendas";
            this.grpNova.ResumeLayout(false);
            this.grpNova.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
