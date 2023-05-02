using Lab09;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OteroExamenConcurrente2017
{
    public class VectorModulusProgram
    {

        private const string CSV_SEPARATOR = ";";

        static void Main(string[] args)
        {
            int[] vector = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] vector2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Exercise1();
            Exercise2();
            Exercise3(vector);
            Exercise4(vector, vector2);
        }

        static void ShowLine(TextWriter stream, int numberOfThreads, long ticks, double result)
        {
            stream.WriteLine("{0}{3}{1:N0}{3}{2:N2}{3}", numberOfThreads, ticks, result, CSV_SEPARATOR);
        }

        static void Exercise1()
        {
            const int maximumNumberOfThreads = 10;
            int value = 7000;
            // I get the bitcoin data and I will use it to do the same process as with the random vector
            double[] vector = new double[] { 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10 };
            double[] vector2 = new double[] { 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10 };
            Stopwatch time = new Stopwatch();

            Master master = new Master(vector, vector2, 1, value);
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
                master = new Master(vector, vector2, numberOfThreads, value);
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

        static void Exercise2()
        {
            const int maximumNumberOfThreads = 10;
            int value = 7000;
            // I get the bitcoin data and I will use it to do the same process as with the random vector
            double[] vector = new double[] { 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10 };
            double[] vector2 = new double[] { 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10 };
            Stopwatch time = new Stopwatch();

            Master master = new Master(vector, vector2, 1, value);
            time.Start();
            double result = master.ComputeModulus2();
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
                master = new Master(vector, vector2, numberOfThreads, value);
                time.Start();
                result = master.ComputeModulus2();
                time.Stop();
                Console.WriteLine("Elapsed time: {0:N0} clock ticks.", time.ElapsedTicks);
                ShowLine(multipleThreadOutput, numberOfThreads, time.ElapsedTicks, result);
                GC.Collect(); // Launching the collector
                GC.WaitForFullGCComplete();
            }
            output.Close();
            multipleThreadOutput.Close();
        }

        static void Exercise3(int[] numbers)
        {
            int sumX = 0;
            int sumX2 = 0;

            Parallel.Invoke(() =>
            {
                for (int i = 0; i < numbers.Length; i += 2)
                {
                    Interlocked.Add(ref sumX, numbers[i]);
                }
                //for (int i = 0; i < numbers.Length; i += 2)
                //{
                //    lock(list){
                //      sumX += numbers[i];
                //    }
                //}
            }, () =>
            {
                for (int i = 0; i < numbers.Length; i += 2)
                {
                    Interlocked.Add(ref sumX2, (int)Math.Pow(numbers[i],2));
                }
            }, () =>
            {
                for (int i = 1; i < numbers.Length; i += 2)
                {
                    Interlocked.Add(ref sumX, numbers[i]);
                }
            }, () =>
            {
                for (int i = 1; i < numbers.Length; i += 2)
                {
                    Interlocked.Add(ref sumX2, (int)Math.Pow(numbers[i], 2));
                }
            });

            Console.WriteLine(Math.Pow(sumX2 - sumX, 2));
        }

        static void Exercise4(int[] vector, int[] vector2)
        {
            IDictionary<int,int> dict1 = new Dictionary<int,int>();
            IDictionary<int, int> dict2 = new Dictionary<int, int>();
            IDictionary<int, int> res = new Dictionary<int, int>();

            Parallel.Invoke(() =>
            {
                vector.AsParallel().Aggregate(dict1, (d, y) =>
                {
                    if (d.ContainsKey(y))
                    {
                        d[y]++;
                    }
                    else
                    {
                        d.Add(y, 1);
                    }
                    return d;
                });
            }, () =>
            {
                vector2.AsParallel().Aggregate(dict2, (d, y) =>
                {
                    if (d.ContainsKey(y))
                    {
                        d[y]++;
                    }
                    else
                    {
                        d.Add(y, 1);
                    }
                    return d;
                });
            });
            Parallel.For(0, dict1.Count(), x =>
            {
                res.Add(dict1.Keys.ElementAt(x), dict1[dict1.Keys.ElementAt(x)]);
            });
            Parallel.For(0, dict2.Count(), x =>
            {
                if (res.ContainsKey(dict2.Keys.ElementAt(x)))
                {
                    res[dict2.Keys.ElementAt(x)] += dict2[dict2.Keys.ElementAt(x)];
                }
                else
                {
                    res.Add(dict2.Keys.ElementAt(x), dict2[dict2.Keys.ElementAt(x)]);
                }
            });

            foreach(var elem in res)
            {
                Console.WriteLine(elem);
            }
        }

    }
}
