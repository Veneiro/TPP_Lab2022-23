using Lab09;
using System;

namespace Examen1
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            int[] vector = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] vector2 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Master master = new Master(vector, vector2, 10);
            int[] result = master.ComputeVectorialSum(4);
            foreach(int i in result)
            {
                Console.WriteLine(i + ',');
            }
        }
    }
}
