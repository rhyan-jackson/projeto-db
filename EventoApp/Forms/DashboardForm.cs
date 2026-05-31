using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EventoApp.Database;

namespace EventoApp.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            CarregarEstatisticas();
        }

        private void CarregarEstatisticas()
        {
            try
            {
                DataTable dtGeral = DbHelper.ExecuteQuery("SELECT * FROM dbo.vw_EstatísticasGerais");
                DataTable dtPortaria = DbHelper.ExecuteQuery("SELECT * FROM dbo.vw_MetricasPortaria");

                decimal receitaTotal = 0;
                int totalInscritos = 0;
                int totalSucessos = 0;
                int totalNegados = 0;

                foreach (DataRow r in dtGeral.Rows)
                {
                    receitaTotal += Convert.ToDecimal(r["Receita_Total"]);
                    totalInscritos += Convert.ToInt32(r["Total_Inscritos"]);
                }

                foreach (DataRow r in dtPortaria.Rows)
                {
                    totalSucessos += Convert.ToInt32(r["Sucessos"]);
                    totalNegados += Convert.ToInt32(r["Fraudes_Erros"]);
                }

                int totalAcessos = totalSucessos + totalNegados;
                double taxaRejeicao = totalAcessos > 0 ? ((double)totalNegados / totalAcessos) * 100 : 0;
                decimal ticketMedio = totalInscritos > 0 ? receitaTotal / totalInscritos : 0;

                int bilhetesUtilizados = Convert.ToInt32(DbHelper.ExecuteScalar("SELECT COUNT(*) FROM dbo.Token WHERE status = 'Usado'"));

                lblReceitaTotal.Text = string.Format("{0:C2}", receitaTotal);
                lblTotalAcessos.Text = totalAcessos.ToString();
                lblTaxaRejeicao.Text = string.Format("{0:F1}%", taxaRejeicao);
                label65.Text = string.Format("{0:C2}", ticketMedio);
                lblBilhetesUtilizados.Text = bilhetesUtilizados.ToString();

                chartReceita.Series[0].Points.Clear();
                chartReceita.Titles.Clear();
                chartReceita.Titles.Add("Faturação por Evento");
                foreach (DataRow r in dtGeral.Rows)
                {
                    chartReceita.Series[0].Points.AddXY(r["Evento"].ToString(), Convert.ToDouble(r["Receita_Total"]));
                }

                chartPortaria.Series[0].Points.Clear();
                chartPortaria.Titles.Clear();
                chartPortaria.Titles.Add("Auditoria de Acessos");
                chartPortaria.Series[0].Points.AddXY("Permitidos", totalSucessos);
                chartPortaria.Series[0].Points.AddXY("Negados/Erros", totalNegados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar indicadores estatísticos: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void chartReceita_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void DashboardForm_Load(object sender, EventArgs e) { }
    }
}