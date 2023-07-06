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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.hashmat = new System.Windows.Forms.Button();
            this.timeComparissonChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.somaFatoriais = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timeComparissonChart)).BeginInit();
            this.SuspendLayout();
            // 
            // hashmat
            // 
            this.hashmat.Location = new System.Drawing.Point(39, 42);
            this.hashmat.Name = "hashmat";
            this.hashmat.Size = new System.Drawing.Size(75, 23);
            this.hashmat.TabIndex = 0;
            this.hashmat.Text = "Hashmat";
            this.hashmat.UseVisualStyleBackColor = true;
            this.hashmat.Click += new System.EventHandler(this.Hashmat_Click);
            // 
            // timeComparissonChart
            // 
            chartArea1.Name = "ChartArea1";
            this.timeComparissonChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.timeComparissonChart.Legends.Add(legend1);
            this.timeComparissonChart.Location = new System.Drawing.Point(26, 138);
            this.timeComparissonChart.Name = "timeComparissonChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.timeComparissonChart.Series.Add(series1);
            this.timeComparissonChart.Size = new System.Drawing.Size(739, 300);
            this.timeComparissonChart.TabIndex = 2;
            this.timeComparissonChart.Text = "Time comparisson";
            // 
            // somaFatoriais
            // 
            this.somaFatoriais.Location = new System.Drawing.Point(141, 42);
            this.somaFatoriais.Name = "somaFatoriais";
            this.somaFatoriais.Size = new System.Drawing.Size(134, 23);
            this.somaFatoriais.TabIndex = 3;
            this.somaFatoriais.Text = "Soma Fatoriais";
            this.somaFatoriais.UseVisualStyleBackColor = true;
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

