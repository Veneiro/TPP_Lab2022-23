using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Intrinsics;
using System.Threading.Tasks;

namespace Lab09
{

    internal class Worker
    {

        private double[] vector;
        private double[] vector2;

        private int indexFrom, indexTo;

        private double result;
        private int value = 0;



        internal double Result
        {
            get { return this.result; }
        }

        internal Worker(double[] vector, double[] vector2, int indexFrom, int indexTo, int value)
        {
            this.vector = vector;
            this.vector2 = vector2;
            this.indexFrom = indexFrom;
            this.indexTo = indexTo;
            this.value = value;

        }

        internal void Calculate()
        {
            this.result = 0;
            for (int i = indexFrom; i <= indexTo; i++)
            {
                result += Math.Pow(vector[i] + vector2[i], 2);
            }
            this.result = Math.Sqrt(result);
        }

        internal void CalculateDistanceF()
        {
            double difference = 0;
            double result = 0;
            IList<double> list = new List<double>();
            Parallel.For(0, vector.Length,
                i =>
                {
                    lock (list)
                    {
                        difference = vector[i] - vector2[i];
                        double pow = Math.Pow(difference, 2);
                        list.Add(pow);
                    }
                });
            this.result = Math.Sqrt(list.AsParallel().Sum(x => x));
        }
    }
}
