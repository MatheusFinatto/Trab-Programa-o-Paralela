using System;
using System.Diagnostics;
using System.Threading;
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
            timeComparissonChart.ChartAreas[0].AxisY.Maximum = 100;


            Thread[] threads = new Thread[2];
            endThreads = 0;

            // Populate valores array
            Random random = new Random();
            for (int i = 0; i < 80; i++)
            {
                for (int j = 0; j < 2; j++) 
                    valores[i, j] = random.Next(10);
            }



            threads[0] = new Thread(() =>
            {
                for (int i = 0; i < 40; i++)
                {
                    resultados[i] = 0;
                    
                    if (valores[i, 0] > valores[i, 1]) Console.WriteLine($"THREAD 1: Resposta {i}: VITÓRIA");
                    else if ((valores[i, 0] == valores[i, 1]))  Console.WriteLine($"THREAD 1: Resposta {i}: EMPATE");
                    else Console.WriteLine($"THREAD 1: Resposta {i}: DERROTA");
                   
                }

                    endThreads++;
                
            });

            threads[1] = new Thread(() =>
            {
                for (int i = 40; i < 80; i++)
                {
                    resultados[i] = 1;
                    
                    if (valores[i, 0] > valores[i, 1]) Console.WriteLine($"THREAD 2: Resposta {i}: VITÓRIA");
                    else if ((valores[i, 0] == valores[i, 1]))  Console.WriteLine($"THREAD 2: Resposta {i}: EMPATE");
                    else Console.WriteLine($"THREAD 2: Resposta {i}: DERROTA");
                    
                }
                    endThreads++;
            });

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            threads[0].Start();
            threads[1].Start();

            while (true)
            {

                if (endThreads >= 2)
                {
                    break;
                }
                
            }
            stopwatch.Stop();


            //Console.WriteLine(string.Join(", ", resultados));
            

            TimeSpan elapsedTime = stopwatch.Elapsed;
            timeSeries.Points.AddXY(2, elapsedTime.TotalMilliseconds);
        }
    }
}
