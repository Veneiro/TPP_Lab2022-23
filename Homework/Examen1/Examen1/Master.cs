using System;
using System.Threading;

namespace Lab09
{

    public class Master
    {

        private int[] vector;
        private int[] vector2;

        private int[] result;

        private int numberOfThreads;

        public Master(int[] vector, int[] vector2, int numberOfThreads)
        {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("Number of threads has to be less or equal to the number of elements in the vector");
            if (numberOfThreads < 1 || numberOfThreads > vector2.Length)
                throw new ArgumentException("Number of threads has to be less or equal to the number of elements in the vector");
            this.vector = vector;
            this.vector2 = vector2;
            this.numberOfThreads = numberOfThreads;
            this.result = new int[vector.Length];
        }

        public int[] ComputeVectorialSum(int j)
        {
            Worker[] workers = new Worker[this.numberOfThreads];
            int elementsPerThread = this.vector.Length / numberOfThreads;

            for (int i = 0; i < this.numberOfThreads; i++)
            {
                workers[i] = new Worker(this.vector, this.vector2,i,j,this.result);
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
            return result;

        }

    }

}
