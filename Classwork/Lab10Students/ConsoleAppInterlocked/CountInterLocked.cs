using Lab09;
using System;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab09 {

    public class Index
    {
        int index;
        public Index()
        {
            index = 0;
        }
        public int TheIndex
        {
            get { return index; }
            set { index = value; }
        }
    }
    public class CountInterLocked {
        private BitcoinValueData[] vector;

        private int numberOfThreads;
        //add an attribute of type Index
        

        long result;

        public CountInterLocked(BitcoinValueData[] vector, int numberOfThreads) {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the number of elements in the vector.");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
            result = 0;
            //initialize the attribute of type Index
            
        }
        public long ComputeTimesAbove(double threshold) {

            Thread[] threads = new Thread[numberOfThreads];
            for(int i=0;i<threads.Length;i++) {
                //call the constructor of the class Thread with the method Compute as parameter
                //the parameter of the method Compute is the value of the threshold parameter
                //use a lambda expression


                threads[i].Name = "Worker Vector Modulus " + (i+1); 
                threads[i].Priority = ThreadPriority.BelowNormal; 
                threads[i].Start();  
            }
            //think about the need to wait for the threads to finish
            //do that if needed
            
            //think about the need to accumulate partial results
            //do that if needed

            return result;
        }

        internal void Compute(double threshold)
        {
            //mind de indentation
            //define variable/s if needed
            
            //loop
                //lock the index

                    //copy the value of TheIndex attribute

                    //increment the value of TheIndex attribute

                //end lock
                //if the index is out of range, break the loop

                //if the value of the vector in the position workerIndex is greater than threshold, increment result


            //end loop
        }

    }

}
