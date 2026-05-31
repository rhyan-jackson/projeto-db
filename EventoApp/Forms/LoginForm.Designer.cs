namespace IngressosFM.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Size = new System.Drawing.Size(340, 35);
            this.lblTitulo.Text = "EventoApp - Login";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblEmail
            //
            this.lblEmail.Location = new System.Drawing.Point(30, 70);
            this.lblEmail.Size = new System.Drawing.Size(80, 23);
            this.lblEmail.Text = "Email:";
            //
            // lblPassword
            //
            this.lblPassword.Location = new System.Drawing.Point(30, 110);
            this.lblPassword.Size = new System.Drawing.Size(80, 23);
            this.lblPassword.Text = "Password:";
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(120, 67);
            this.txtEmail.Size = new System.Drawing.Size(250, 23);
            //
            // txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(120, 107);
            this.txtPassword.Size = new System.Drawing.Size(250, 23);
            this.txtPassword.UseSystemPasswordChar = true;
            //
            // btnEntrar
            //
            this.btnEntrar.Location = new System.Drawing.Point(120, 150);
            this.btnEntrar.Size = new System.Drawing.Size(120, 30);
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.Location = new System.Drawing.Point(250, 150);
            this.btnCancelar.Size = new System.Drawing.Size(120, 30);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // LoginForm
            //
            this.AcceptButton = this.btnEntrar;
            this.CancelButton = this.btnCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
