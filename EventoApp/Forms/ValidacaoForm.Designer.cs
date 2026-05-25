namespace EventoApp.Forms
{
    partial class ValidacaoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpScan;
        private System.Windows.Forms.Label lblPonto, lblQr, lblResultadoTitulo;
        private System.Windows.Forms.ComboBox cmbPonto;
        private System.Windows.Forms.TextBox txtQr;
        private System.Windows.Forms.Button btnValidar, btnAtualizar;
        private System.Windows.Forms.CheckBox chkUsadoUnico;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.DataGridView dgv;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpScan = new System.Windows.Forms.GroupBox();
            this.lblPonto = new System.Windows.Forms.Label();
            this.lblQr = new System.Windows.Forms.Label();
            this.lblResultadoTitulo = new System.Windows.Forms.Label();
            this.cmbPonto = new System.Windows.Forms.ComboBox();
            this.txtQr = new System.Windows.Forms.TextBox();
            this.btnValidar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.chkUsadoUnico = new System.Windows.Forms.CheckBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.grpScan.SuspendLayout();
            this.SuspendLayout();

            this.grpScan.Location = new System.Drawing.Point(12, 12);
            this.grpScan.Size = new System.Drawing.Size(960, 180);
            this.grpScan.Text = "Validação de Acesso";

            this.lblPonto.Location = new System.Drawing.Point(15, 30); this.lblPonto.Text = "Ponto Acesso:"; this.lblPonto.Size = new System.Drawing.Size(110, 23);
            this.cmbPonto.Location = new System.Drawing.Point(130, 27); this.cmbPonto.Size = new System.Drawing.Size(300, 23);
            this.cmbPonto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblQr.Location = new System.Drawing.Point(15, 60); this.lblQr.Text = "Código QR lido:"; this.lblQr.Size = new System.Drawing.Size(110, 23);
            this.txtQr.Location = new System.Drawing.Point(130, 57); this.txtQr.Size = new System.Drawing.Size(300, 23);
            this.txtQr.Font = new System.Drawing.Font("Consolas", 10F);

            this.chkUsadoUnico.Location = new System.Drawing.Point(15, 90);
            this.chkUsadoUnico.Size = new System.Drawing.Size(400, 23);
            this.chkUsadoUnico.Text = "Marcar token como 'Usado' após validar (single-use)";
            this.chkUsadoUnico.Checked = false;

            this.btnValidar.Location = new System.Drawing.Point(450, 27); this.btnValidar.Size = new System.Drawing.Size(150, 60);
            this.btnValidar.Text = "Validar";
            this.btnValidar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);

            this.lblResultadoTitulo.Location = new System.Drawing.Point(620, 30); this.lblResultadoTitulo.Text = "Resultado:";
            this.lblResultadoTitulo.Size = new System.Drawing.Size(100, 23);
            this.lblResultado.Location = new System.Drawing.Point(620, 55);
            this.lblResultado.Size = new System.Drawing.Size(320, 80);
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblResultado.Text = "(aguarda validação)";

            this.grpScan.Controls.Add(this.lblPonto); this.grpScan.Controls.Add(this.lblQr);
            this.grpScan.Controls.Add(this.lblResultadoTitulo);
            this.grpScan.Controls.Add(this.cmbPonto); this.grpScan.Controls.Add(this.txtQr);
            this.grpScan.Controls.Add(this.chkUsadoUnico);
            this.grpScan.Controls.Add(this.btnValidar);
            this.grpScan.Controls.Add(this.lblResultado);

            this.dgv.Location = new System.Drawing.Point(12, 200);
            this.dgv.Size = new System.Drawing.Size(960, 280);
            this.dgv.ReadOnly = true; this.dgv.AllowUserToAddRows = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.btnAtualizar.Location = new System.Drawing.Point(870, 485); this.btnAtualizar.Size = new System.Drawing.Size(100, 30);
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 525);
            this.Controls.Add(this.grpScan);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnAtualizar);
            this.Text = "Validação de Acesso";
            this.grpScan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
