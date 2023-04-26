using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Lab09
{

    internal class Worker
    {

        private int[] vector;
        private int[] vector2;

        private int[] result;

        private int thread;
        private int jump;

        internal int[] Result
        {
            get { return this.result; }
        }

        internal Worker(int[] vector, int[] vector2, int thread, int jump, int[] result)
        {
            this.vector = vector;
            this.vector2 = vector2;
            this.thread = thread;
            this.jump = jump;
            this.result = result;
        }

        internal void Calculate()
        {
            for(int i = thread; i< vector.Length; i += jump)
                this.result[i] = vector[i] + vector2[i];
        }
    }
}
