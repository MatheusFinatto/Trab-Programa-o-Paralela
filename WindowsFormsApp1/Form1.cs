using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void hashmat_Click(object sender, EventArgs e)
        {
            // Define the list of cases
            List<string> cases = new List<string>
            {
                "10 12",
                "10 14",
                "100 200",
                "50 60",
                "30 20",
                "80 90",
                "15 25",
                "70 50",
                "40 35",
                "55 65",
                "95 85",
                "120 110",
                "180 190",
                "230 220",
                "500 510",
                "240 250",
                "350 340",
                "430 440",
                "660 670",
                "890 880",
                "950 960",
                "770 780",
                "880 870",
                "1100 1110",
                "1050 1040",
                "1230 1240",
                "1350 1360",
                "1450 1440",
                "1660 1670",
                "1780 1770",
                "1900 1910",
                "2000 2010",
                "2100 2090",
                "2350 2340",
                "2490 2480",
                "2530 2520",
                "2670 2680",
                "2750 2760",
                "2800 2810",
                "3000 3010",
                "3100 3110",
                "3250 3240",
                "3300 3290",
                "3450 3460",
                "3510 3520",
                "3620 3630",
                "3700 3710",
                "3850 3840",
                "3910 3920",
                "4000 4010",
                "4100 4110",
                "4250 4260",
                "4370 4360"
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

                    // Calculate the difference
                    int difference = Math.Abs(hashmatSoldiers - opponentSoldiers);
                }

                // Stop the stopwatch
                stopwatch.Stop();

                // Get the elapsed time
                TimeSpan elapsedTime = stopwatch.Elapsed;

                // Add a data point to the series with the thread count and elapsed time
                timeSeries.Points.AddXY(threadCount, elapsedTime.TotalMilliseconds);
            }
        }
    }
    }