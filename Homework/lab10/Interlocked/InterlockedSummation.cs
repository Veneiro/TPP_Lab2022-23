using System;
using System.Threading;

namespace lab10
{
    internal class InterlockedSummation : Summation
    {
        internal InterlockedSummation(int value, int numberOfThreads) :
            base(value, numberOfThreads)
        {
        }
        
        override protected void DecrementValue()
        {
            Interlocked.Decrement(ref this.value);
        }
    }
}
