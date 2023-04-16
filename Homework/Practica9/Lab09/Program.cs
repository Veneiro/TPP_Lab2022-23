using System;

using System.IO;
using System.Diagnostics;
namespace Lab09
{

    public class VectorModulusProgram
    {

        private const string CSV_SEPARATOR = ";";

        static void Main(string[] args)
        {
            const int maximumNumberOfThreads = 50;
            int value = 7000;
            // I get the bitcoin data and I will use it to do the same process as with the random vector
            BitcoinValueData[] vector = Utils.GetBitcoinData();
            Stopwatch time = new Stopwatch();

            Master master = new Master(vector, 1, value);
            time.Start();
            double result = master.ComputeModulus();
            time.Stop();

            System.IO.StreamWriter output = new System.IO.StreamWriter("outputOneThread.csv");
            ShowLine(output, 1, time.ElapsedTicks, result);
            GC.Collect(); // Launching the collector
            GC.WaitForFullGCComplete();

            // If we increment the number of threads the performance is worse (We try from 1 to 50 threads)

            System.IO.StreamWriter multipleThreadOutput = new System.IO.StreamWriter("outputMultithread.csv");


            for (int numberOfThreads = 1; numberOfThreads <= maximumNumberOfThreads; numberOfThreads++)
            {
                time.Reset();
                master = new Master(vector, numberOfThreads, value);
                time.Start();
                result = master.ComputeModulus();
                time.Stop();
                Console.WriteLine("Elapsed time: {0:N0} clock ticks.", time.ElapsedTicks);
                ShowLine(multipleThreadOutput, numberOfThreads, time.ElapsedTicks, result);
                GC.Collect(); // Launching the collector
                GC.WaitForFullGCComplete();
            }
            output.Close();
            multipleThreadOutput.Close();
        }

        static void ShowLine(TextWriter stream, int numberOfThreads, long ticks, double result)
        {
            stream.WriteLine("{0}{3}{1:N0}{3}{2:N2}{3}", numberOfThreads, ticks, result, CSV_SEPARATOR);
        }

    }
}
