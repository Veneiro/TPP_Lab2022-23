using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;


namespace TPP.Concurrency.Lab12
{


    class Lab12
    {
        /// <summary>
        /// Creates a new dictionary form the two parameters with all the keys of both dictionaries
        /// and adding the values of the common keys
        /// </summary>
        /// <typeparam name="T">The type of the keys</typeparam>
        /// <param name="a">First dict</param>
        /// <param name="b">Second dict</param>
        /// <returns>New dict</returns>
        static IDictionary<T, int> AddHistogram<T>(IDictionary<T, int> a, IDictionary<T, int> b)
        {
            IDictionary<T, int> result = new Dictionary<T, int>();
            //for each pair key value in a
            foreach (var e in a)
            {
                //if there is the same key in b
                if (b.ContainsKey(e.Key))
                    //add the sum of the values of the key in a and b
                    result.Add(e.Key, e.Value + b[e.Key]);
                else
                    //otherwise, add the value of the key in a
                    result.Add(e.Key, e.Value);
            }
            //add the elements of b that are not in a
            foreach (var e in b)
                if (!a.ContainsKey(e.Key))
                    result.Add(e.Key, e.Value);
            return result;
        }
        /// <summary>
        /// Creates a random vector of short integers with the specified number of elements
        /// between the lowest and greatest values both included
        /// </summary>
        /// <param name="numberOfElements"> Number of elements</param>
        /// <param name="lowest">Min value</param>
        /// <param name="greatest">Max value</param>
        /// <returns></returns>
        static short[] CreateRandomShortVector(int numberOfElements, short lowest, short greatest)
        {
            short[] vector = new short[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (short)random.Next(lowest, greatest + 1);
            return vector;
        }
        /// <summary>
        /// Creates a random vector of int with the specified number of elements
        /// between the lowest and greatest values both included
        /// </summary>
        /// <param name="numberOfElements"> Number of elements</param>
        /// <param name="lowest">Min value</param>
        /// <param name="greatest">Max value</param>
        /// <returns></returns>
        static int[] CreateRandomIntVector(int numberOfElements, int lowest, int greatest)
        {
            int[] vector = new int[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = random.Next(lowest, greatest + 1);
            return vector;
        }
        /// <summary>
        /// Creates a random vector of double with the specified number of elements
        /// between min and max
        /// </summary>
        /// <param name="numberOfElements"> Number of elements</param>
        /// <param name="min">Min value</param>
        /// <param name="max">Max value</param>
        /// <returns></returns>
        static double[] CreateRandomDoubleVector(int numberOfElements, double min, double max)
        {
            double[] vector = new double[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = random.NextDouble() * (max - min) + min;
            return vector;
        }
        /// <summary>
        /// Counts the number of occurrences of each element in the vector
        /// Sequential version
        /// </summary>
        /// <param name="v">The data</param>
        /// <returns>A dictionary with the histogram</returns>
        static IDictionary<short, int> countForSeq(short[] v)
        {
            IDictionary<short, int> result = new Dictionary<short, int>();
            for (int i = 0; i < v.Length; i++)
            {
                if (result.ContainsKey(v[i]))
                    result[v[i]]++;
                else
                    result.Add(v[i], 1);
            }
            return result;
        }

        /// <summary>
        /// Sums the values of all the key-value pairs in the dictionary of whatever key type, int value
        /// </summary>
        /// <param name="d">The dictionary</param>
        /// <returns>The sum of the values</returns>
        static int SumDict<T>(IDictionary<T, int> d)
        {
            return d.Aggregate(0, (acc, p) => acc + p.Value);
        }
        /// <summary>
        /// Shows the values of a collection 
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="c">The collection</param>
        /// <param name="sep">character between values</param>
        /// <param name="end">character after all the elements</param>
        static void Show<T>(IEnumerable<T> c, char sep = '\n', char end = '\n')
        {
            foreach (var e in c)
                Console.Write("{0}{1}", e, sep);
            Console.WriteLine(end);
        }

        /// <summary>
        /// Variance of a vector of short integers, sequential implementation
        /// </summary>
        /// <param name="vector">The data</param>
        /// <returns>A double with the result</returns>
        static double VarLinq(IEnumerable<short> vector)
        {
            //we could use Average instead
            var mean = vector.Aggregate(0.0, (acc, el) => acc + el) / vector.Count();
            return vector.Aggregate(0.0, (acc, el) => acc + Math.Pow((el - mean), 2.0)) / vector.Count();
        }



        /// <summary>
        /// Mean of a vector of short integers, sequential implementation
        /// </summary>
        /// <param name="vector">The data</param>
        /// <returns>The mean as a double</returns>
        static double Mean(IEnumerable<short> vector)
        {
            return vector.Aggregate(0.0, (acc, el) => acc + el) / (double)vector.Count();
        }
        /// <summary>
        /// Mean of the squares of the elements of a vector of short integers, sequential implementation
        /// </summary>
        /// <param name="vector">The data</param>
        /// <returns>The mean as a double</returns>
        static double MeanX2(IEnumerable<short> vector)
        {
            return vector.Aggregate(0.0, (acc, el) => acc + el * el) / (double)vector.Count();
        }
        /// <summary>
        /// Good old is prime
        /// </summary>
        /// <param name="n">The number to check</param>
        /// <returns>A boolean true if it is a prime number, false otherwise</returns>
        static bool IsPrime(int n)
        {
            if (n < 2)
                return false;
            for (int i = 2; i <= n / 2; i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        /// <summary>
        /// Sequential computation fo the modulus of a vector
        /// </summary>
        /// <param name="v">The data</param>
        /// <returns>The modulus</returns>
        static double ModulusSequential(int[] v)
        {
            return Math.Sqrt(v.Aggregate((acc, e) => acc += e * e));

        }


        /// <summary>
        /// Compares two dictionaries of T and int
        /// </summary>
        /// <typeparam name="T">The type of the keys</typeparam>
        /// <param name="a">The first dict</param>
        /// <param name="b">The second dict</param>
        /// <returns>true if they hold the same key value pairs, false otherwise</returns>
        static bool CompareDicts<T>(IDictionary<T, int> a, IDictionary<T, int> b) where T : IComparable<T>
        {
            //non equal number of key/value pairs
            if (a.Count != b.Count)
                return false;
            //(this could be done with a single loop ordering by key)
            //different keys
            foreach (var t in a.Keys.OrderBy(x => x).Zip(b.Keys.OrderBy(x => x)))
                if (t.First.CompareTo(t.Second) != 0)
                    return false;
            //different values
            foreach (var k in a.Keys)
                if (b[k] != a[k])
                    return false;
            return true;
        }
        /// <summary>
        /// Compares to IEnumerable collections regardless of the ordering
        /// </summary>
        /// <typeparam name="T">The type of the elements</typeparam>
        /// <param name="a">First collection</param>
        /// <param name="b">Second collection</param>
        /// <returns>true if they hold the same elements, false otherwise</returns>
        static bool Compare<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            if (a.Count() != b.Count())
                return false;
            return a.OrderBy(x => x).SequenceEqual(b.OrderBy(x => x));
        }
        /// <summary>
        /// Standard deviation sequential version
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The result</returns>
        static double sequentialSD(IEnumerable<double> data)
        {
            double mean = data.Average();
            double sd = Math.Sqrt(data.Aggregate(0.0, (Result, x) => Result += (x - mean) * (x - mean)) / (data.Count() - 1));
            return sd;
        }
        /// <summary>
        /// Returns the average time in ticks of a function
        /// averaged over several executions
        /// </summary>
        /// <typeparam name="T1">Input data type</typeparam>
        /// <typeparam name="T2">Returning type</typeparam>
        /// <param name="f">The function</param>
        /// <param name="data">The data</param>
        /// <param name="times">The number of executions</param>
        /// <returns></returns>
        static long AverageTicks<T1, T2>(Func<T1, T2> f, T1 data, int times)
        {
            DateTime before, after;
            long total = 0;
            for (int i = 0; i < times; i++)
            {
                before = DateTime.Now;
                var x = f(data);
                after = DateTime.Now;
                total += (after - before).Ticks;
            }
            return total / times;
        }
        /// <summary>
        /// Returns the average time in ticks of a function
        /// averaged over several executions
        /// </summary>
        /// <typeparam name="T1">Input data type</typeparam>
        /// <typeparam name="T2">Returning type</typeparam>
        /// <param name="f">The function</param>
        /// <param name="data">The data</param>
        /// <param name="t">An additional int parameter for f</param>
        /// <param name="times">The number of executions</param>
        /// <returns></returns>
        static long AverageTicks<T1, T2>(Func<T1, int, T2> f, T1 data, int t, int times)
        {
            DateTime before, after;
            long total = 0;
            for (int i = 0; i < times; i++)
            {
                before = DateTime.Now;
                var x = f(data, t);
                after = DateTime.Now;
                total += (after - before).Ticks;
            }
            return total / times;
        }

        /// <summary>
        /// Subset of primes in an int array, sequential implementation
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>A collection with the prime numbers</returns>
        static IEnumerable<int> PrimesFor(int[] data)
        {
            IList<int> result = new List<int>();
            for (int i = 0; i < data.Length; i++)
            {
                lock (result)
                    if (IsPrime(data[i]))
                        result.Add(data[i]);
            }
            return result;
        }

        static IEnumerable<int> PrimesParallelFor(int[] data)
        {
            IList<int> result = new List<int>();
            Parallel.For(0, data.Length, i =>
            {
                lock (result)
                    if (IsPrime(data[i]))
                        result.Add(data[i]);
            });
            return result;
        }

        static IEnumerable<int> PrimesParallelForLocal(int[] data)
        {
            List<int> result = new List<int>();
            Parallel.For(0, data.Length,
            () => new List<int>(),
            (i, loop, partialResult) =>
            {
                if (IsPrime(data[i]))
                    partialResult.Add(data[i]);
                return partialResult;
            },
            (x) =>
            {
                lock (result)
                    result.AddRange(x);
            });
            return result;
        }

        static IEnumerable<int> PrimesParallelForEach(int[] data)
        {
            IList<int> result = new List<int>();
            Parallel.ForEach(data, element =>
            {
                lock (result)
                    if (IsPrime(element))
                        result.Add(element);
            });
            return result;
        }

        static IEnumerable<int> PrimesParallelForEachLocal(int[] data)
        {
            List<int> result = new List<int>();
            Parallel.ForEach(data,
            () => new List<int>(),
            (element, loop, partialResult) =>
            {
                if (IsPrime(element))
                    partialResult.Add(element);
                return partialResult;
            },
            (x) =>
            {
                lock (result)
                    result.AddRange(x);
            }
            );
            return result;
        }

        static IEnumerable<int> PrimesLocalAggregate(int[] data)
        {
            return data.AsParallel().Aggregate(
                () => new List<int>(),
                (partialResult, element) =>
                {
                    if (IsPrime(element))
                        partialResult.Add(element);
                    return partialResult;

                },
                (finalResult, thisThread) =>
                {
                    finalResult.AddRange(thisThread);
                    return finalResult;
                },
                x => x
                );
        }

        static IEnumerable<int> PrimesInvoke(int[] data)
        {
            IList<int> result = new List<int>();
            for (int i = 0; i < data.Length; i += 2)
            {
                if (IsPrime(data[i]))
                    result.Add(data[i]);
            }
            for (int i = 1; i < data.Length; i += 2)
            {
                if (IsPrime(data[i]))
                    result.Add(data[i]);
            }
            return result;
        }

        static IEnumerable<int> PrimesInvoke2(int[] data)
        {
            List<int> result = new List<int>();
            Parallel.Invoke(() =>
            {
                for (int i = 0; i < data.Length; i += 2)
                {
                    if (IsPrime(data[i]))
                        lock(result)
                        result.Add(data[i]);
                }
            },
            () =>
            {
                for (int i = 1; i < data.Length; i += 2)
                {
                    if (IsPrime(data[i]))
                        lock(result)
                        result.Add(data[i]);
                }
            }
            );
            return result;
        }

        /// <summary>
        /// double array modulus, sequential Linq
        /// </summary>
        /// <param name="col">The data</param>
        /// <returns>The result</returns>
        static double ModulusSequential(IEnumerable<double> col)
        {
            return Math.Sqrt(col.Aggregate(0.0, (acc, e) => acc += e * e));
        }
        /// <summary>
        /// double array modulus, lame PLinq implementation
        /// </summary>
        /// <param name="col">The data</param>
        /// <returns>The result</returns>
        static double ModulusPlinq(IEnumerable<double> col)
        {
            return Math.Sqrt(col.AsParallel().Aggregate(0.0, (acc, e) => acc += e * e));
        }

        static void Main()
        {
            var data = CreateRandomDoubleVector(1000000, -1, 1);
            Console.WriteLine(" Modulus sequential {0} \nmodulus PLINQ {1} ", ModulusSequential(data), ModulusPlinq(data));
            Console.WriteLine(" Modulus sequential {0} \nmodulus PLINQ {1}", AverageTicks(ModulusSequential, data, 30), AverageTicks(ModulusPlinq, data, 30));

            var integers = CreateRandomIntVector(10000, 2, 10000).OrderBy(i => i).ToArray();
            var primesFor = PrimesFor(integers);
            Show(primesFor.Take(100), sep: ' ');

            var primesForParallel = PrimesParallelFor(integers);
            Show(primesForParallel.Take(100), sep: ' ');

            var primesForEachParallel = PrimesParallelForEach(integers);
            Show(primesForEachParallel.Take(100), sep: ' ');

            var primesForParallelLocal = PrimesParallelForLocal(integers);
            Show(primesForParallelLocal.Take(100), sep: ' ');

            var primesForEachParallelLocal = PrimesParallelForEachLocal(integers);
            Show(primesForEachParallelLocal.Take(100), sep: ' ');

            var primesLocalAgg = PrimesLocalAggregate(integers);
            Show(primesLocalAgg.Take(100), sep: ' ');

            var primesInvoke = PrimesInvoke2(integers);
            Show(primesInvoke.Take(100), sep: ' ');

            Console.WriteLine(Compare(primesFor, primesForParallel));
            Console.WriteLine(Compare(primesFor, primesForEachParallel));
            Console.WriteLine(Compare(primesFor, primesForParallelLocal));
            Console.WriteLine(Compare(primesFor, primesForEachParallelLocal));
            Console.WriteLine($"{primesFor.Count()}, {primesForParallel.Count()}, " +
                $"{primesForEachParallel.Count()}, {primesForParallelLocal.Count()}, " +
                $"{primesForEachParallelLocal.Count()}, {primesLocalAgg.Count()}, {primesInvoke.Count()}");
        }
    }
}
