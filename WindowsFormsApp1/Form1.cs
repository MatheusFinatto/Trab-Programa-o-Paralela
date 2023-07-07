using System;
using System.Collections.Generic;
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


        static readonly int QTD_CASOS = 80;
        static long  [,] valores = new long[QTD_CASOS, 2];
        int[] qtdThreads = { 1, 2, 4, 8, 16 };
        static int endThreads = 0;

        static string actualProblem = "";
        static int presenteIteração = 0;
        static int qtdDeCasosInicial = 0;
        static int qtdDeCasosFinal = 0;
        static int threadAtual = 0;

        static List<string> outputResults = new List<string>(); // Armazena os resultados das threads
        //static int[] resultados = new int[QTD_CASOS];


        void ProcessThread()
        {
            threadAtual++;
            // a cada thread iniciada, atualiza a qtd final para que compute diferentes dados
            qtdDeCasosFinal = QTD_CASOS / qtdThreads[presenteIteração] + qtdDeCasosInicial;

            //aqui irão as funções de resolução do problema;
            if (actualProblem == "hashmat") ResolveHashmat();
            if (actualProblem == "fatorial") ResolveFatorial();

            // a quantidade inicial deve ser atualizada depois do for e não antes, para que a primeira iteração ocorra com o qtdDeCasosInicial = 0
            qtdDeCasosInicial += QTD_CASOS / qtdThreads[presenteIteração];
            endThreads++;
        }

        private void MainFunction()
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
            //timeComparissonChart.ChartAreas[0].AxisY.Maximum = 100;


            Stopwatch stopwatch = new Stopwatch();

            //inicia o loop principal (numero de testes feitos)
            for (int i = 0; i < qtdThreads.Length; i++)
            {

                //cria um array de threads que irá receber as instâncias
                Thread[] threadsExecutaveis = new Thread[qtdThreads[i]];
                endThreads = 0;
                presenteIteração = i;
                qtdDeCasosInicial = 0;
                qtdDeCasosFinal = 0;
                threadAtual = 0;

                for (int j = 0; j < qtdThreads[i]; j++)
                {
                    threadsExecutaveis[j] = new Thread(ProcessThread);
                }


                stopwatch.Start();

                for (int j = 0; j < qtdThreads[i]; j++)
                {
                    //instancia a qtd de threads necessarias para a presente iteração 
                    //se for a primeira, instancia 1 thread, se for a ultima, instancia 16 threads, etc;
                    threadsExecutaveis[j].Start();
                }


                while (true)
                {
                    if (endThreads >= qtdThreads[i])
                    {
                        break;
                    }
                }

                stopwatch.Stop();

                TimeSpan elapsedTime = stopwatch.Elapsed;
                timeSeries.Points.AddXY(qtdThreads[i], elapsedTime.TotalMilliseconds);
            }
        }


        private void Hashmat_Click(object sender, EventArgs e)
        {
            outputResults.Clear();
            actualProblem = "hashmat";

            // Populate valores array
            Random random = new Random();
            for (int i = 0; i < QTD_CASOS; i++)
            {
                for (int j = 0; j < 2; j++)
                    valores[i, j] = random.Next(10);
            }

            MainFunction();

            //prints on the console
            foreach (string result in outputResults)
            {
                Console.WriteLine(result);
            }
        }

        private void ResolveHashmat()
        {
            for (int i = qtdDeCasosInicial; i < qtdDeCasosFinal; i++)
            {
                if (valores[i, 0] > valores[i, 1])
                    outputResults.Add($"{i} - THREAD {threadAtual}: Vitória");
                else if (valores[i, 0] < valores[i, 1])
                    outputResults.Add($"{i} - THREAD {threadAtual}: Derrota");
                else
                    outputResults.Add($"{i} - THREAD {threadAtual}: Empate");
            }
        }



        private void somaFatoriais_Click(object sender, EventArgs e)
        {
            outputResults.Clear();
            actualProblem = "fatorial";

            // Populate valores array
            Random random = new Random();
            for (int i = 0; i < QTD_CASOS; i++)
            {
                for (int j = 0; j < 2; j++)
                    valores[i, j] = random.Next(25);
            }

            MainFunction();

            //prints on the console
            foreach (string result in outputResults)
            {
                Console.WriteLine(result);
            }
        }

        public static long Factorial(long n)
        {
            if (n == 0)
                return 1;

            return n * Factorial(n - 1);
        }

        private void ResolveFatorial()
        {



            for (int i = qtdDeCasosInicial; i < qtdDeCasosFinal; i++)
            {
                Console.WriteLine($"{i} - THREAD {threadAtual}: {Factorial(valores[i, 0]) + Factorial(valores[i, 1])}" );
            }
        }
    }
}

