namespace EventoApp.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartReceita = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPortaria = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReceitaTotal = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalAcessos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTaxaRejeicao = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTicketMedio = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblBilhetesUtilizados = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartReceita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPortaria)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartReceita
            // 
            chartArea1.Name = "ChartArea1";
            this.chartReceita.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartReceita.Legends.Add(legend1);
            this.chartReceita.Location = new System.Drawing.Point(12, 125);
            this.chartReceita.Name = "chartReceita";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartReceita.Series.Add(series1);
            this.chartReceita.Size = new System.Drawing.Size(436, 275);
            this.chartReceita.TabIndex = 0;
            this.chartReceita.Text = "chart1";
            this.chartReceita.Click += new System.EventHandler(this.chartReceita_Click);
            // 
            // chartPortaria
            // 
            chartArea2.Name = "ChartArea1";
            this.chartPortaria.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartPortaria.Legends.Add(legend2);
            this.chartPortaria.Location = new System.Drawing.Point(456, 125);
            this.chartPortaria.Name = "chartPortaria";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartPortaria.Series.Add(series2);
            this.chartPortaria.Size = new System.Drawing.Size(406, 275);
            this.chartPortaria.TabIndex = 1;
            this.chartPortaria.Text = "chart2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblReceitaTotal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 100);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receita Total";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReceitaTotal
            // 
            this.lblReceitaTotal.AutoSize = true;
            this.lblReceitaTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceitaTotal.Location = new System.Drawing.Point(27, 32);
            this.lblReceitaTotal.Name = "lblReceitaTotal";
            this.lblReceitaTotal.Size = new System.Drawing.Size(102, 41);
            this.lblReceitaTotal.TabIndex = 3;
            this.lblReceitaTotal.Text = "0,00 €";
            this.lblReceitaTotal.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTotalAcessos);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(184, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(155, 100);
            this.panel2.TabIndex = 3;
            // 
            // lblTotalAcessos
            // 
            this.lblTotalAcessos.AutoSize = true;
            this.lblTotalAcessos.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAcessos.Location = new System.Drawing.Point(60, 32);
            this.lblTotalAcessos.Name = "lblTotalAcessos";
            this.lblTotalAcessos.Size = new System.Drawing.Size(35, 41);
            this.lblTotalAcessos.TabIndex = 3;
            this.lblTotalAcessos.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total de Acessos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTaxaRejeicao);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(356, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(155, 100);
            this.panel3.TabIndex = 4;
            // 
            // lblTaxaRejeicao
            // 
            this.lblTaxaRejeicao.AutoSize = true;
            this.lblTaxaRejeicao.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxaRejeicao.Location = new System.Drawing.Point(45, 32);
            this.lblTaxaRejeicao.Name = "lblTaxaRejeicao";
            this.lblTaxaRejeicao.Size = new System.Drawing.Size(61, 41);
            this.lblTaxaRejeicao.TabIndex = 3;
            this.lblTaxaRejeicao.Text = "0%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Taxa de Rejeição";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblTicketMedio);
            this.panel4.Controls.Add(this.label65);
            this.panel4.Location = new System.Drawing.Point(531, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(155, 100);
            this.panel4.TabIndex = 5;
            // 
            // lblTicketMedio
            // 
            this.lblTicketMedio.AutoSize = true;
            this.lblTicketMedio.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketMedio.Location = new System.Drawing.Point(27, 32);
            this.lblTicketMedio.Name = "lblTicketMedio";
            this.lblTicketMedio.Size = new System.Drawing.Size(102, 41);
            this.lblTicketMedio.TabIndex = 3;
            this.lblTicketMedio.Text = "0,00 €";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(4, 4);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(85, 16);
            this.label65.TabIndex = 0;
            this.label65.Text = "Ticket Médio";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label65.Click += new System.EventHandler(this.label7_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblBilhetesUtilizados);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(707, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(155, 100);
            this.panel5.TabIndex = 5;
            // 
            // lblBilhetesUtilizados
            // 
            this.lblBilhetesUtilizados.AutoSize = true;
            this.lblBilhetesUtilizados.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBilhetesUtilizados.Location = new System.Drawing.Point(64, 32);
            this.lblBilhetesUtilizados.Name = "lblBilhetesUtilizados";
            this.lblBilhetesUtilizados.Size = new System.Drawing.Size(35, 41);
            this.lblBilhetesUtilizados.TabIndex = 3;
            this.lblBilhetesUtilizados.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Bilhetes Utilizados";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 450);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chartPortaria);
            this.Controls.Add(this.chartReceita);
            this.Name = "DashboardForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartReceita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPortaria)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartReceita;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPortaria;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblReceitaTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalAcessos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTaxaRejeicao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTicketMedio;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblBilhetesUtilizados;
        private System.Windows.Forms.Label label9;
    }
}