using System;
using System.Threading;

namespace Lab09
{

    public class Master
    {

        private BitcoinValueData[] vector;

        private int numberOfThreads;
        private int value = 0;

        public Master(BitcoinValueData[] vector, int numberOfThreads, int value)
        {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("Number of threads has to be less or equal to the number of elements in the vector");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
            this.value = value;
        }

        public double ComputeModulus()
        {
            Worker[] workers = new Worker[this.numberOfThreads];
            int elementsPerThread = this.vector.Length / numberOfThreads;

            for (int i = 0; i < this.numberOfThreads; i++)
            {
                workers[i] = new Worker(this.vector,
                    i * elementsPerThread,
                    (i < this.numberOfThreads - 1) ? (i + 1) * elementsPerThread - 1 : this.vector.Length - 1 // último
                    , value);
            }
            // Using calculate method
            Thread[] threads = new Thread[workers.Length];
            for (int i = 0; i < workers.Length; i++)
            {
                // We have to pass an Action to the Thread constructor, 
                // in that case the Calculate method on the Worker class (delegates)

                threads[i] = new Thread(workers[i].Calculate);
                threads[i].Name = "Worker Vector Modulus " + (i + 1);
                threads[i].Priority = ThreadPriority.BelowNormal;
                threads[i].Start();
            }

            // In that way we can be sure the the result variable is not picked
            // until all the threads finish their task 
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
            // The calculate mehtod return the result in the Result vaiable of the Worker class
            long result = 0;
            foreach (Worker worker in workers)
                result += worker.Result;
            return result;

        }

    }

}
