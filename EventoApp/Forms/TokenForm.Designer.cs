namespace IngressosFM.Forms
{
    partial class TokenForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblId, lblQr, lblStatus, lblTipo;
        private System.Windows.Forms.TextBox txtId, txtQr;
        private System.Windows.Forms.ComboBox cmbStatus, cmbTipo;
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
            this.lblQr = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtQr = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();

            this.dgv.Location = new System.Drawing.Point(12, 12);
            this.dgv.Size = new System.Drawing.Size(760, 280);
            this.dgv.ReadOnly = true; this.dgv.AllowUserToAddRows = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.MultiSelect = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);

            this.lblId.Location = new System.Drawing.Point(12, 310); this.lblId.Text = "ID Token:"; this.lblId.Size = new System.Drawing.Size(100, 23);
            this.lblQr.Location = new System.Drawing.Point(12, 340); this.lblQr.Text = "Código QR:"; this.lblQr.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.Location = new System.Drawing.Point(12, 370); this.lblStatus.Text = "Status:"; this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblTipo.Location = new System.Drawing.Point(12, 400); this.lblTipo.Text = "Tipo de acesso:"; this.lblTipo.Size = new System.Drawing.Size(100, 23);

            this.txtId.Location = new System.Drawing.Point(120, 307); this.txtId.Size = new System.Drawing.Size(120, 23); this.txtId.ReadOnly = true;
            this.txtQr.Location = new System.Drawing.Point(120, 337); this.txtQr.Size = new System.Drawing.Size(300, 23);
            this.cmbStatus.Location = new System.Drawing.Point(120, 367); this.cmbStatus.Size = new System.Drawing.Size(200, 23);
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Location = new System.Drawing.Point(120, 397); this.cmbTipo.Size = new System.Drawing.Size(200, 23);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnNovo.Location = new System.Drawing.Point(560, 307); this.btnNovo.Size = new System.Drawing.Size(100, 30); this.btnNovo.Text = "Novo";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnGuardar.Location = new System.Drawing.Point(670, 307); this.btnGuardar.Size = new System.Drawing.Size(100, 30); this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnEliminar.Location = new System.Drawing.Point(560, 343); this.btnEliminar.Size = new System.Drawing.Size(100, 30); this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnAtualizar.Location = new System.Drawing.Point(670, 343); this.btnAtualizar.Size = new System.Drawing.Size(100, 30); this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblId); this.Controls.Add(this.lblQr); this.Controls.Add(this.lblStatus); this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtId); this.Controls.Add(this.txtQr); this.Controls.Add(this.cmbStatus); this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.btnNovo); this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar); this.Controls.Add(this.btnAtualizar);
            this.Text = "Gestão de Tokens";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
