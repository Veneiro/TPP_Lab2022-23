
using Lab09;
using System;

namespace TPP.Laboratory.Concurrency.Lab09 {

    internal class Worker {

        private BitcoinValueData[] vector;


        private long result;
        //add an attribut of type Index
        
        internal long Result {
            get { return this.result; }
        }

        //add a constructor that additionally receives an Index
        internal Worker(BitcoinValueData[] vector,  Index index)
        {
            this.vector = vector;
            //assign the received index to the attribute
        }

        internal void Compute(double threshold) {
            this.result = 0;
            //define additional variable/s if needed

            //forever loop

                //lock the index

                    //copy the value of TheIndex attribute
                    
                    //increment the value of TheIndex attribute
                    
                
                //end lock
                //if the value of the index is greater than the length of the vector, break the loop

                //if the value of the vector at the index is greater than the threshold, increment the local result

            //end loop
            
        }

    }

}
