namespace EventoApp.Forms
{
    partial class TokenForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblId, lblQr, lblStatus, lblTipo;
        private System.Windows.Forms.TextBox txtId, txtQr;
        private System.Windows.Forms.ComboBox cmbStatus, cmbTipo;
        private System.Windows.Forms.Button btnAtualizar;

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
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.picQRCode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeight = 29;
            this.dgv.Location = new System.Drawing.Point(14, 13);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(869, 299);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(14, 331);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(114, 25);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID Token:";
            // 
            // lblQr
            // 
            this.lblQr.Location = new System.Drawing.Point(14, 363);
            this.lblQr.Name = "lblQr";
            this.lblQr.Size = new System.Drawing.Size(114, 25);
            this.lblQr.TabIndex = 2;
            this.lblQr.Text = "Código QR:";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(14, 395);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(114, 25);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status:";
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(14, 427);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(114, 25);
            this.lblTipo.TabIndex = 4;
            this.lblTipo.Text = "Tipo de acesso:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(137, 327);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(137, 22);
            this.txtId.TabIndex = 5;
            // 
            // txtQr
            // 
            this.txtQr.Location = new System.Drawing.Point(137, 359);
            this.txtQr.Name = "txtQr";
            this.txtQr.Size = new System.Drawing.Size(342, 22);
            this.txtQr.TabIndex = 6;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new System.Drawing.Point(137, 391);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(228, 24);
            this.cmbStatus.TabIndex = 7;
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Location = new System.Drawing.Point(137, 423);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(228, 24);
            this.cmbTipo.TabIndex = 8;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(766, 366);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(114, 32);
            this.btnAtualizar.TabIndex = 12;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // picQRCode
            // 
            this.picQRCode.Location = new System.Drawing.Point(381, 395);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(176, 176);
            this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQRCode.TabIndex = 13;
            this.picQRCode.TabStop = false;
            this.picQRCode.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // TokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 592);
            this.Controls.Add(this.picQRCode);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblQr);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtQr);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.btnAtualizar);
            this.Name = "TokenForm";
            this.Text = "Gestão de Tokens";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox picQRCode;
    }
}
