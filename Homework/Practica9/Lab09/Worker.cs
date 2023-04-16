using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Lab09
{

    internal class Worker
    {

        private BitcoinValueData[] vector;

        private int indexFrom, indexTo;

        private int result;
        private int value = 0;



        internal int Result
        {
            get { return this.result; }
        }

        internal Worker(BitcoinValueData[] vector, int indexFrom, int indexTo, int value)
        {
            this.vector = vector;
            this.indexFrom = indexFrom;
            this.indexTo = indexTo;
            this.value = value;

        }

        internal void Calculate()
        {
            this.result = 0;
            for (int i = indexFrom; i <= indexTo; i++)
            {
                if (vector[i].Value >= value)
                    result++;
            }
        }
    }
}
