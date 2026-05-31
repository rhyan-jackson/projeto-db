namespace IngressosFM.Forms
{
    partial class StandForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblId, lblArea, lblSetor;
        private System.Windows.Forms.TextBox txtId, txtArea;
        private System.Windows.Forms.ComboBox cmbSetor;
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
            this.lblArea = new System.Windows.Forms.Label();
            this.lblSetor = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.cmbSetor = new System.Windows.Forms.ComboBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();

            this.dgv.Location = new System.Drawing.Point(12, 12);
            this.dgv.Size = new System.Drawing.Size(760, 280);
            this.dgv.ReadOnly = true;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.MultiSelect = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);

            this.lblId.Location = new System.Drawing.Point(12, 310); this.lblId.Text = "ID Stand:"; this.lblId.Size = new System.Drawing.Size(100, 23);
            this.lblArea.Location = new System.Drawing.Point(12, 340); this.lblArea.Text = "Área (m²):"; this.lblArea.Size = new System.Drawing.Size(100, 23);
            this.lblSetor.Location = new System.Drawing.Point(12, 370); this.lblSetor.Text = "Setor:"; this.lblSetor.Size = new System.Drawing.Size(100, 23);

            this.txtId.Location = new System.Drawing.Point(120, 307); this.txtId.Size = new System.Drawing.Size(120, 23); this.txtId.ReadOnly = true;
            this.txtArea.Location = new System.Drawing.Point(120, 337); this.txtArea.Size = new System.Drawing.Size(120, 23);
            this.cmbSetor.Location = new System.Drawing.Point(120, 367); this.cmbSetor.Size = new System.Drawing.Size(300, 23);
            this.cmbSetor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

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
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblId); this.Controls.Add(this.lblArea); this.Controls.Add(this.lblSetor);
            this.Controls.Add(this.txtId); this.Controls.Add(this.txtArea); this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.btnNovo); this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar); this.Controls.Add(this.btnAtualizar);
            this.Text = "Gestão de Stands";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
