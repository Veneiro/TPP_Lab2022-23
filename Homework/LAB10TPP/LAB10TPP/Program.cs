using lab02TPP;
using System;
using System.Collections.Generic;
using System.Threading;

namespace LAB10TPP
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            ConcurrentQueue<int> concurrentQueue= new ConcurrentQueue<int>();
            Thread[] threads = new Thread[10];
            for(int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(()=>concurrentQueue.Add(i+1));
                threads[i].Start();
                threads[i].Join();
                // Assert.AreEqual(i+1, concurrentQueue.NumberOfElements);
                Console.WriteLine("Executing thread " + i);
            }
            Console.WriteLine();
            Console.WriteLine("---- ADD LIST ----");
            foreach(var e in concurrentQueue.list)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.WriteLine("---- PEEK LIST ----");
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() => Console.WriteLine(concurrentQueue.Peek()));
                threads[i].Start();
                threads[i].Join();
            }

            Console.WriteLine();
            Console.WriteLine("---- EXTRACT LIST ----");
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() => Console.WriteLine(concurrentQueue.Extract()));
                threads[i].Start();
                threads[i].Join();
            }
        }
    }
}
