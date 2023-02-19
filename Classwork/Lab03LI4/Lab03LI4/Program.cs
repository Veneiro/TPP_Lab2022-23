using Lab03;
using System;

namespace Lab03LI4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Interval interval;
            try
            {
                interval = new Interval(3.0, 4.0);
                Console.WriteLine(interval.Size());
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                Console.WriteLine("This is shown always");
            }
            Console.WriteLine("{0} intersected with {1} = {2}", a, b, a.Intersection(b));
            */

            Interval a = new Interval(1,3), b = new Interval(2,3), c = new Interval(), d = new Interval(4,5), e = new Interval(1,3);
            Console.WriteLine("{0} intersected with {1} = {2}", a, b, a.Intersection(b));
            Console.WriteLine("{0} intersected with {1} = {2}", b, a, b.Intersection(a));
            Console.WriteLine("{0} intersected with {1} = {2}", b, c, b.Intersection(c));
            Console.WriteLine("{0} intersected with {1} = {2}", a, d, a.Intersection(d));
            Console.WriteLine("{0} equals {1} = {2}",a, b, a.Equals(b));
            Console.WriteLine("{0} equals {1} = {2}",a, e, a.Equals(e));
            Console.WriteLine("{0} equals {1} = {2}",a, 666, a.Equals(666));
        }
    }
}
