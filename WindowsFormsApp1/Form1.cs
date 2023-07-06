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

        private void Hashmat_Click(object sender, EventArgs e)
        {
            // Define the list of cases
            List<string> cases = new List<string>
            {
                "10 12",
                "10 14",
                "100 200",
            };

            // Define the number of threads to test
            int[] threadCounts = { 1, 2, 4, 8, 16 };

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

            // Process each number of threads
            foreach (int threadCount in threadCounts)
            {
                // Create a Stopwatch for each iteration
                Stopwatch stopwatch = new Stopwatch();

                // Start the stopwatch
                stopwatch.Start();

                // Process each case using the specified number of threads
                foreach (string caseString in cases)
                {
                    // Split the case into two numbers
                    string[] numbers = caseString.Split(' ');

                    // Parse the numbers
                    int hashmatSoldiers = int.Parse(numbers[0]);
                    int opponentSoldiers = int.Parse(numbers[1]);
                }

                // Stop the stopwatch
                stopwatch.Stop();

                // Get the elapsed time
                TimeSpan elapsedTime = stopwatch.Elapsed;

                // Add a data point to the series with the thread count and elapsed time
                timeSeries.Points.AddXY(threadCount, elapsedTime.TotalMilliseconds);
            }
        }

        private void SomaFatoriais_Click(object sender, EventArgs e)
        {
            // Define the list of cases
            List<string> cases = new List<string>
            {
                "4 4",
                "0 0",
                "0 2",
            };

            // Define the number of threads to test
            int[] threadCounts = { 1, 2, 4, 8, 16 };

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

            // Process each number of threads
            foreach (int threadCount in threadCounts)
            {
                // Create a Stopwatch for each iteration
                Stopwatch stopwatch = new Stopwatch();

                // Start the stopwatch
                stopwatch.Start();

                // Process each case using the specified number of threads
                foreach (string caseString in cases)
                {
                    // Split the case into two numbers
                    string[] numbers = caseString.Split(' ');

                    // Parse the numbers
                    long firstFactorial = CalcularFatorial(int.Parse(numbers[0]));
                    long secondFactorial = CalcularFatorial(int.Parse(numbers[1]));
                }

                // Stop the stopwatch
                stopwatch.Stop();

                // Get the elapsed time
                TimeSpan elapsedTime = stopwatch.Elapsed;

                // Add a data point to the series with the thread count and elapsed time
                timeSeries.Points.AddXY(threadCount, elapsedTime.TotalMilliseconds);
            }
        }
        private static long CalcularFatorial(int number)
        {
            long factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}