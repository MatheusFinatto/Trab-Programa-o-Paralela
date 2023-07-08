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
       /* void* ThreadExerc1061()
            {
                for (int i = 0; i < 25; i++)
                {

                    int result = abs(entradas[i][0] - entradas[i][1]);

                    resultados[i] = result;

                    printf("THREAD 1: RESOLVED ENTRY #%d (%d - %d) = %d\n", i, entradas[i][0], entradas[i][1], result);
                }
            }

            int qtdThreads = [1, 2, 4, 8, 16];

        for (int i = 0; i<qtdThreads.size(); i++) {
            pthread_t threadsExecutaveis[qtdThreads[i]];

            //startWatch

            for (int j = 0; j<qtdThreads[i]; j++) {
                pthread_create(&threadsExecutaveis[j], NULL, ThreadExerc1061, NULL);
        }

        //stopWatch
        //guarda valor no gráfico

    }*/

        public Form1()
        {
            InitializeComponent();
            PopulateCases();
        }


        static readonly int QTD_CASOS = 80;
        static int  [,] valores = new int[QTD_CASOS, 2];
        int[] qtdThreads = { 1, 2, 4, 8, 16 };
        static int endThreads = 0;

        static string actualProblem = "";
        static int presenteIteração = 0;
        static int qtdDeCasosInicial = 0;
        static int qtdDeCasosFinal = 0;
        static int threadAtual = 0;

        static List<string> outputResults = new List<string>(); // Armazena os resultados das threads
        //static long[] resultados = new long[QTD_CASOS];

        //POPULATES THE INPUT ARRAY WITH NUMBERS FROM 0-15
        private void PopulateCases()
        {
            // Populate valores array
            Random random = new Random();
            for (long i = 0; i < QTD_CASOS; i++)
            {
                for (long j = 0; j < 2; j++)
                    valores[i, j] = random.Next(15);
            }
        }

        private void clickHandlerHelper()
        {
            outputResults.Clear();
            MainFunction();
            foreach (string result in outputResults)
            {
                Console.WriteLine(result);
            }
        }
       
        void ProcessThread()
        {
            threadAtual++;
            // a cada thread iniciada, atualiza a qtd final para que compute diferentes dados
            qtdDeCasosFinal = QTD_CASOS / qtdThreads[presenteIteração] + qtdDeCasosInicial;

            if (actualProblem == "soma") ResolveSoma();
            if (actualProblem == "hashmat") ResolveHashmat();
            if (actualProblem == "fatorial") ResolveFatorial();
            if (actualProblem == "figurinhas") ResolveFigurinhas();
            if (actualProblem == "A_INCRIVEL_LENDA_DO_INCRIVEL_FLAVIAO_JOSÉ.mp4") ResolveFLAVIAO();

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
            timeComparissonChart.ChartAreas[0].AxisY.Maximum = 500;

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
            actualProblem = "hashmat";
            clickHandlerHelper();
        }

        private void ResolveHashmat()
        {
            for (long i = qtdDeCasosInicial; i < qtdDeCasosFinal; i++)
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
            actualProblem = "fatorial";
            clickHandlerHelper();
        }

        public static long Factorial(long n)
        {
            if (n == 0)
                return 1;

            return n * Factorial(n - 1);
        }

        private void ResolveFatorial()
        {
            for (long i = qtdDeCasosInicial; i < qtdDeCasosFinal; i++)
            {
                Console.WriteLine($"{i} - THREAD {threadAtual}: {Factorial(valores[i, 0]) + Factorial(valores[i, 1])}" );
            }
        }

        private void Figurinhas_Click(object sender, EventArgs e)
        {
            actualProblem = "figurinhas";
            clickHandlerHelper();
        }

        private long MaximoDaPilha(long m, long n)
        {
            if (n == 0)
            {
                return m;
            }
            return MaximoDaPilha(n, m % n);
        }

        private void ResolveFigurinhas()
        {
            for (long i = qtdDeCasosInicial; i < qtdDeCasosFinal; i++)
            {
                Console.WriteLine($"{i} - THREAD {threadAtual}: {MaximoDaPilha(valores[i, 0], valores[i, 1])}");
            }
        }

        private void Soma_Click(object sender, EventArgs e)
        {
            actualProblem = "soma";
            clickHandlerHelper();
        }

        private void ResolveSoma()
        {
            for (long i = qtdDeCasosInicial; i < qtdDeCasosFinal; i++)
            {
                Console.WriteLine($"{i} - THREAD {threadAtual}: {Soma(valores[i, 0], valores[i, 1])}");
            }
        }

        private long Soma(long m, long n)
        {
            return m + n;
        }

        private void ALendaDeFlaviusJosephusFodase_Click(object sender, EventArgs e)
        {
            //sim, sou doente.
            actualProblem = "A_INCRIVEL_LENDA_DO_INCRIVEL_FLAVIAO_JOSÉ.mp4";
            clickHandlerHelper();
        }

        private void ResolveFLAVIAO()
        {
            for (long i = qtdDeCasosInicial; i < qtdDeCasosFinal; i++)
            {
                Console.WriteLine($"{i} - THREAD {threadAtual}: {FlaviusJosephus(valores[i, 0], valores[i, 1])}");
            }
        }

        int FlaviusJosephus(int n, int k)
        {
            int result = 0;
            for (int i = 2; i <= n; i++)
            {
                result = (result + k) % i;
            }
            return result;
        }

    }
}

