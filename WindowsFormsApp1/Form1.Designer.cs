namespace WindowsFormsApp1
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.hashmat = new System.Windows.Forms.Button();
            this.timeComparissonChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.somaFatoriais = new System.Windows.Forms.Button();
            this.figurinhas = new System.Windows.Forms.Button();
            this.soma = new System.Windows.Forms.Button();
            this.aLendaDeFlaviusJosephusFodase = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timeComparissonChart)).BeginInit();
            this.SuspendLayout();
            // 
            // hashmat
            // 
            this.hashmat.Location = new System.Drawing.Point(198, 97);
            this.hashmat.Name = "hashmat";
            this.hashmat.Size = new System.Drawing.Size(130, 25);
            this.hashmat.TabIndex = 0;
            this.hashmat.Text = "Hashmat";
            this.hashmat.UseVisualStyleBackColor = true;
            this.hashmat.Click += new System.EventHandler(this.Hashmat_Click);
            // 
            // timeComparissonChart
            // 
            chartArea2.Name = "ChartArea1";
            this.timeComparissonChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.timeComparissonChart.Legends.Add(legend2);
            this.timeComparissonChart.Location = new System.Drawing.Point(26, 138);
            this.timeComparissonChart.Name = "timeComparissonChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.timeComparissonChart.Series.Add(series2);
            this.timeComparissonChart.Size = new System.Drawing.Size(739, 300);
            this.timeComparissonChart.TabIndex = 2;
            this.timeComparissonChart.Text = "Time comparisson";
            // 
            // somaFatoriais
            // 
            this.somaFatoriais.Location = new System.Drawing.Point(334, 97);
            this.somaFatoriais.Name = "somaFatoriais";
            this.somaFatoriais.Size = new System.Drawing.Size(130, 25);
            this.somaFatoriais.TabIndex = 3;
            this.somaFatoriais.Text = "Soma Fatoriais";
            this.somaFatoriais.UseVisualStyleBackColor = true;
            this.somaFatoriais.Click += new System.EventHandler(this.somaFatoriais_Click);
            // 
            // figurinhas
            // 
            this.figurinhas.Location = new System.Drawing.Point(470, 97);
            this.figurinhas.Name = "figurinhas";
            this.figurinhas.Size = new System.Drawing.Size(130, 25);
            this.figurinhas.TabIndex = 4;
            this.figurinhas.Text = "Figurinhas";
            this.figurinhas.UseVisualStyleBackColor = true;
            this.figurinhas.Click += new System.EventHandler(this.Figurinhas_Click);
            // 
            // soma
            // 
            this.soma.Location = new System.Drawing.Point(62, 97);
            this.soma.Name = "soma";
            this.soma.Size = new System.Drawing.Size(130, 25);
            this.soma.TabIndex = 5;
            this.soma.Text = "Soma Simples";
            this.soma.UseVisualStyleBackColor = true;
            this.soma.Click += new System.EventHandler(this.Soma_Click);
            // 
            // aLendaDeFlaviusJosephusFodase
            // 
            this.aLendaDeFlaviusJosephusFodase.Location = new System.Drawing.Point(606, 97);
            this.aLendaDeFlaviusJosephusFodase.Name = "aLendaDeFlaviusJosephusFodase";
            this.aLendaDeFlaviusJosephusFodase.Size = new System.Drawing.Size(130, 25);
            this.aLendaDeFlaviusJosephusFodase.TabIndex = 6;
            this.aLendaDeFlaviusJosephusFodase.Text = "Josephus";
            this.aLendaDeFlaviusJosephusFodase.UseVisualStyleBackColor = true;
            this.aLendaDeFlaviusJosephusFodase.Click += new System.EventHandler(this.ALendaDeFlaviusJosephusFodase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aLendaDeFlaviusJosephusFodase);
            this.Controls.Add(this.soma);
            this.Controls.Add(this.figurinhas);
            this.Controls.Add(this.somaFatoriais);
            this.Controls.Add(this.timeComparissonChart);
            this.Controls.Add(this.hashmat);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.timeComparissonChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button hashmat;
        private System.Windows.Forms.DataVisualization.Charting.Chart timeComparissonChart;
        private System.Windows.Forms.Button somaFatoriais;
        private System.Windows.Forms.Button figurinhas;
        private System.Windows.Forms.Button soma;
        private System.Windows.Forms.Button aLendaDeFlaviusJosephusFodase;
    }
}

