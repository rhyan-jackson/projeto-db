using System;
using System.Data;
using System.Windows.Forms;
using EventoApp.Database;

namespace EventoApp.Forms
{
    public partial class LoginForm : Form
    {
        /// <summary>Email do utilizador autenticado (devolvido a quem abriu o form).</summary>
        public string UtilizadorAutenticado { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var pass = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Preenche email e password.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var count = Convert.ToInt32(DbHelper.ExecuteScalar(
                    "EXEC dbo.sp_Login @email, @pass",
                    DbHelper.P("@email", email),
                    DbHelper.P("@pass",  pass)));

                if (count > 0)
                {
                    UtilizadorAutenticado = email;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Credenciais inválidas.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ligar à base de dados:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
