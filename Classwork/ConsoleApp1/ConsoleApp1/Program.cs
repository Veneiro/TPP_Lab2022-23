using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{
    internal class Program
    {
        static void ApplyAction<T> (IEnumerable<T> e, Action<T> a)
        {
            foreach (T t in e)
            {
                a (t);
            }
        }

        static int Count<T>(IEnumerable<T> v, Predicate<T> p)
        {
            int count = 0;
            foreach (T t in v)
                if (p(t))
                    count++;
            return count;
        }

        static bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        static bool IsPrime(int n) 
        {
            if (n < 2)
                return false;
            for(int i=2;i*i<=n;i++)
                if(n%i==0) 
                    return false;
            return true;
        }

        static int FindFirst<T> (IEnumerable<T> v, Predicate<T> p)
        {
            int result = -1, i = 0;
            foreach(var e in v)
            {
                if (p(e))
                {
                    result = i;
                    break;
                }
                i++;
            }
            return result;
        }

        static int FindFirstA<T>(IEnumerable<T> v, Predicate<T> p)
        {
            int result = -1, i = 0;
            bool found = false;
            ApplyAction(v, x =>
            {
                if (p(x) && !found)
                {
                    result = i;
                    found = true;
                }
                i++;
            });
            return result;
        }

        private static int Sub(int a, int b)
        {
            return a - b;
        }

        private static int DoubleApplication(Func<int,int> function, int integer)
        {
            return function(function(integer));
        }

        private static int Twice(int integer)
        {
            return integer + integer;
        }

        private static Func<double, double> ComposeDouble(Func<double, double> function, Func<double,double> function2)
        {
            return x => function(function2(x));
        }

        private static Func<T1, T3> Compose<T1,T2,T3>(Func<T1, T2> func1, Func<T2,T3> func2)
        {
            return x => func2(func1(x));
        }

        static void Main(string[] args)
        {
            Func<double, double> asinh1 = delegate (double x) { return Math.Log(x * x + 1); };
            Func<double, double> asinh2 = (double x) => { return Math.Log(x * x + 1); };
            Func<double, double> asinh3 = x => { return Math.Log(x * x + 1); };
            Console.WriteLine("{0} {1} {2}", asinh1(.5), asinh2(.5), asinh3(.5));
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            ApplyAction(array, x => { Console.Write("{0} ", x); }) ;
            Console.WriteLine();
            Console.WriteLine(Count(array, IsEven));
            Console.WriteLine(Count(array, x=>x%2 == 0));
            Console.WriteLine(Count(array, IsPrime));
            Console.WriteLine(Count(array, n =>
            {
                if (n < 2)
                    return false;
                for (int i = 2; i * i <= n; i++)
                    if (n % i == 0)
                        return false;
                return true;
            }));
            Console.WriteLine(FindFirst(array, IsEven));
            Console.WriteLine(FindFirst(array, IsPrime));
            Console.WriteLine(FindFirst(array, x => !IsEven(x)));
            Console.WriteLine(FindFirst(array, x => !IsPrime(x)));
            var f = ComposeDouble(Math.Log, x => Math.Pow(x, 3.0));
            Console.WriteLine("{0} {1}", f(0.5), Math.Log(Math.Pow(0.5, 3)));
            /*
             *        f           f
             * T1: -------> T2 -------> T3
             *      g(f)
             * T1 -------> T3
             * 
             * composeG<T1,T2,T3>(){}
             */



        }
    }
}
