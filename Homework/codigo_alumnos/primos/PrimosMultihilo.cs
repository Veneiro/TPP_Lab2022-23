using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPP.Lab12.Primos
{
    //Algoritmo basado en la Criba de Eratóstenes
    public class PrimosMultihilo
    {
        private IList<int> primos = new List<int>();
        public int N { get; }

        private static Object o = new Object();

        public PrimosMultihilo()
        {
            N = 100000;
            //Todos los numeros son potencialmente primos


            for (int i = 2; i < N; i++)
                primos.Add(i);
            this.EliminarNoPrimos();

            //Parallel.For(2, N, (i) =>
            //{
            //    lock(primos)
            //      primos.Add(i);
            //});
            //this.EliminarNoPrimos();

        }

        internal virtual void EliminarNoPrimos()
        {

            //for (int i = 2; i < N; i++)
            //{
            //    int n = i;
            //    Parallel.For(n + n, N, j =>
            //    {
            //        if (primos.Contains(j))
            //        {
            //            lock (primos)
            //            {
            //                primos.Remove(j);
            //            }
            //        }
            //    });
            //}

            Parallel.For(2, N, (i) =>
            {
                Cribar(i);
            });

            //Thread[] hilos = new Thread[this.N - 2];
            //for (int i = 2; i < this.N; i++)
            //    hilos[i - 2] = new Thread(() => this.Cribar(i));
            //for (int i = 2; i < this.N; i++)
            //    hilos[i - 2].Start();
            //for (int i = 2; i < this.N; i++)
            //    hilos[i - 2].Join();

            //int numThreads = Environment.ProcessorCount; // Obtener la cantidad de núcleos del procesador
            //Thread[] hilos = new Thread[numThreads];
            //int rangePerThread = (N - 2) / numThreads;
            //for (int i = 0; i < numThreads; i++)
            //{
            //    int start = 2 + i * rangePerThread;
            //    int end = (i == numThreads - 1) ? N : start + rangePerThread;
            //    hilos[i] = new Thread(() => CribarRango(start, end));
            //    hilos[i].Start();
            //}
            //for (int i = 0; i < numThreads; i++)
            //{
            //    hilos[i].Join();
            //}
        }

        internal void CribarRango(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (primos.Contains(i))
                {
                    Cribar(i);
                }
            }
        }

        internal void Cribar(int n)
        {
            for (int i = n + n; i < N; i += n)
            {
                if (primos.Contains(i))
                {
                    primos.Remove(i);
                }
            }
        }

        public bool Primo(int position)
        {
            if ((position == 0) || (position == 1))
                return false;
            return primos.Contains(position);
        }
    }
}
