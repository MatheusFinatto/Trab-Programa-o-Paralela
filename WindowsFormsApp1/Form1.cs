using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int[,] valores = new int[80, 2];
        static int[] resultados = new int[80];
        static int endThreads = 0;
        static object lockObj = new object();

       
        private void Hashmat_Click(object sender, EventArgs e)
        {

            // Clear existing series data in the chart
            timeComparissonChart.Series.Clear();

            // Clear existing chart titles
            timeComparissonChart.Titles.Clear();

            // Create a new series for time measurements
            Series timeSeries = new Series("Time");

            // Set the chart type to a bar chart
            timeSeries.ChartType = SeriesChartType.Column;

            // Add the series to the chart
            timeComparissonChart.Series.Add(timeSeries);

            // Set the chart title and axis labels
            timeComparissonChart.Titles.Add("Comparison of Elapsed Time");
            timeComparissonChart.ChartAreas[0].AxisX.Title = "Thread Count";
            timeComparissonChart.ChartAreas[0].AxisY.Title = "Elapsed Time (ms)";

            Stopwatch stopwatch = new Stopwatch();



            Thread[] threads = new Thread[2];
            endThreads = 0;

            // Populate valores array
            Random random = new Random();
            for (int i = 0; i < 80; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    valores[i, j] = random.Next(100);
                    Console.WriteLine(valores[i, j]);
                }
                Console.WriteLine();
            }

            stopwatch.Start();

            threads[0] = new Thread(() =>
            {
                for (int i = 0; i < 25; i++)
                {
                    resultados[i] = Math.Abs(valores[i, 0] - valores[i, 1]);
                    Console.WriteLine($"THREAD 1: Resposta {i}: {resultados[i]}");
                }

                lock (lockObj)
                {
                    endThreads++;
                }
            });

            threads[1] = new Thread(() =>
            {
                for (int i = 25; i < 80; i++)
                {
                    resultados[i] = Math.Abs(valores[i, 0] - valores[i, 1]);
                    Console.WriteLine($"THREAD 2: Resposta {i}: {resultados[i]}");
                }

                lock (lockObj)
                {
                    endThreads++;
                }
            });

            threads[0].Start();
            threads[1].Start();

            while (true)
            {
                lock (lockObj)
                {
                    if (endThreads >= 2)
                    {
                        break;
                    }
                }
            }
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            timeSeries.Points.AddXY(2, elapsedTime.TotalMilliseconds);
        }
    }
}
