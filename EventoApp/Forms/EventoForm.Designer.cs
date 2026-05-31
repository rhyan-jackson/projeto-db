namespace EventoApp.Forms
{
    partial class EventoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvEventos;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFim;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAtualizar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvEventos = new System.Windows.Forms.DataGridView();
            this.lblId = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFim = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            this.SuspendLayout();
            //
            // dgvEventos
            //
            this.dgvEventos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEventos.AllowUserToAddRows = false;
            this.dgvEventos.AllowUserToDeleteRows = false;
            this.dgvEventos.ReadOnly = true;
            this.dgvEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEventos.MultiSelect = false;
            this.dgvEventos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEventos.Location = new System.Drawing.Point(12, 12);
            this.dgvEventos.Size = new System.Drawing.Size(760, 280);
            this.dgvEventos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEventos_CellClick);
            //
            // lblId
            //
            this.lblId.Location = new System.Drawing.Point(12, 310);
            this.lblId.Size = new System.Drawing.Size(100, 23);
            this.lblId.Text = "ID Evento:";
            //
            // lblNome
            //
            this.lblNome.Location = new System.Drawing.Point(12, 340);
            this.lblNome.Size = new System.Drawing.Size(100, 23);
            this.lblNome.Text = "Nome:";
            //
            // lblInicio
            //
            this.lblInicio.Location = new System.Drawing.Point(12, 370);
            this.lblInicio.Size = new System.Drawing.Size(100, 23);
            this.lblInicio.Text = "Data início:";
            //
            // lblFim
            //
            this.lblFim.Location = new System.Drawing.Point(12, 400);
            this.lblFim.Size = new System.Drawing.Size(100, 23);
            this.lblFim.Text = "Data fim:";
            //
            // txtId
            //
            this.txtId.Location = new System.Drawing.Point(120, 307);
            this.txtId.Size = new System.Drawing.Size(120, 23);
            this.txtId.ReadOnly = true;
            //
            // txtNome
            //
            this.txtNome.Location = new System.Drawing.Point(120, 337);
            this.txtNome.Size = new System.Drawing.Size(400, 23);
            //
            // dtpInicio
            //
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(120, 367);
            this.dtpInicio.Size = new System.Drawing.Size(200, 23);
            //
            // dtpFim
            //
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(120, 397);
            this.dtpFim.Size = new System.Drawing.Size(200, 23);
            //
            // btnNovo
            //
            this.btnNovo.Location = new System.Drawing.Point(560, 307);
            this.btnNovo.Size = new System.Drawing.Size(100, 30);
            this.btnNovo.Text = "Novo";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            //
            // btnGuardar
            //
            this.btnGuardar.Location = new System.Drawing.Point(670, 307);
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnEliminar
            //
            this.btnEliminar.Location = new System.Drawing.Point(560, 343);
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            //
            // btnAtualizar
            //
            this.btnAtualizar.Location = new System.Drawing.Point(670, 343);
            this.btnAtualizar.Size = new System.Drawing.Size(100, 30);
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            //
            // EventoForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvEventos);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.lblFim);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.dtpFim);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAtualizar);
            this.Text = "Gestão de Eventos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
