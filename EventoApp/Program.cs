using System;
using System.Windows.Forms;
using EventoApp.Forms;

namespace EventoApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostra primeiro o Login. Só abre o MainForm se o utilizador
            // se autenticar com sucesso.
            using (var login = new LoginForm())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm(login.UtilizadorAutenticado));
                }
            }
        }
    }
}
