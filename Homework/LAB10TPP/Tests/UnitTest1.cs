using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System;
using LAB10TPP;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int numberOfThreads = 40;
            ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();
            Thread[] threads = new Thread[numberOfThreads];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() => concurrentQueue.Add(i + 1));
                threads[i].Start();
                //Assert.AreEqual(i+1, concurrentQueue.NumberOfElements);
                Console.WriteLine("Executing thread " + i);
                Console.Write("");
                GC.Collect();
                GC.WaitForFullGCApproach();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Assert.AreEqual(numberOfThreads, concurrentQueue.NumberOfElements);
        }
    }
}
