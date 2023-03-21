using PolymorphicSimplyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using TPP.Laboratory.Functional.Lab05;

namespace delegates
{
    public delegate double BasicFunction(double x);
    class Program
    {
        public static double Double(double a)
        {
            return 2 * a;
        }

        //Map function
        static IEnumerable<U> Map3<T, U>(IEnumerable<T> collection, Func<T, U> function)
        {
            U[] res = new U[collection.Count()];

            int i = 0;
            foreach (T elem in collection)
            {
                res[i++] = function(elem);
            }

            //for (int i = 0; i < collection.Count(); i++)
            //{
            //    res[i] = function(collection.ElementAt(i));
            //}

            return res;
        }
        static IEnumerable<T> Map2<T>(IEnumerable<T> collection, Func<T, T> function)
        {
            T[] res = new T[collection.Count()];

            int i = 0;
            foreach(T elem in collection)
            {
                res[i++] = function(elem);
            }

            //for (int i = 0; i < collection.Count(); i++)
            //{
            //    res[i] = function(collection.ElementAt(i));
            //}

            return res;
        }
        static T[] Map<T>(T[] collection, Func<T, T> function)
        {
            T[] res = new T[collection.Length];
            for(int i = 0; i < collection.Length; i++)
            {
                res[i] = function(collection[i]);
            }
            return res;
        }

        static void fillArray(ref double[] a)
        {
            Random r = new Random();
            for(int i = 0; i < a.Length; i++)
            {
                a[i] = r.NextDouble();
            }
        }

        static void Main(string[] args)
        {
            //          Input       Output      f
            // MAP       n:T         n:Q       Find<T,Q>
            // FIND      n:T         1:T       Predicate<T>
            // FILTER    n:T        m<=n:T     Predicate<T>
            // REDUCE    n:T         1:Q       Func<?>
            // SHOW      n:T         ---       ---

            double[] array = new double[10];
            int[] array2 = new int[] { 1, 2, 3, 4 };
            string[] array3 = new string[] { "Hello", "World"};
            fillArray(ref array);
            BasicFunction f = Math.Sqrt;
            f = Math.Sin;
            f = Double;
            Func<double, double> f1 = Math.Sqrt;
            f1 = Math.Sin;
            f1 = Double;
            Console.WriteLine(f(12));

            Console.WriteLine();
            Console.WriteLine("Original: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Result 1: ");

            double[] res = Map(array, f1);
            for (int i = 0; i < res.Length; i++)
            {
                Console.WriteLine(res[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Result 2: ");
            IEnumerable<int> res2 = Map2(array2, (int i) => i + 2);
            foreach(int d in res2)
                Console.WriteLine(d);

            Console.WriteLine();
            Console.WriteLine("Result 3: ");
            IEnumerable<int> res3 = Map3(array3, (string s) => s.Length);
            foreach (int d in res3)
                Console.WriteLine(d);

            //NOT WORKING
            //Console.WriteLine();
            //Console.WriteLine("Result 4: ");
            //IEnumerable<var> res4 = Map3(array3, ((string s) => s.Length).Map());
            //foreach (int d in res3)
            //    Console.WriteLine(d);

            Console.WriteLine();
            Console.WriteLine("Testing Extension Methods:");
            ExtensionMethods em = new ExtensionMethods();

            //ANGLES TESTING
            Angle[] angles = Factory.CreateAngles();
            Console.WriteLine();
            Console.WriteLine("First of Quadrant 2");
            Console.WriteLine(em.Find(angles, angRad => angRad.Quadrant == 2));
            Console.WriteLine();
            Console.WriteLine("Angles in Quadrant 1");
            Predicate<Angle> pAngle = a => a.Quadrant == 1;
            em.Show(em.Filter(angles, pAngle));

            //PEOPLE TESTING
            Person[] people = Factory.CreatePeople();
            Console.WriteLine();
            Console.WriteLine("Person whos name or id number ends in S");
            Console.WriteLine(em.Find(people, person => (person.FirstName[person.FirstName.Length - 1] == 's' || person.IDNumber[person.IDNumber.Length - 1] == 'S')));
            Console.WriteLine();
            Console.WriteLine("List of People whos name ends in s or id number in A");
            Predicate<Person> pPeople = (person => (person.FirstName[person.FirstName.Length - 1] == 's' || person.IDNumber[person.IDNumber.Length - 1] == 'A'));
            em.Show(em.Filter(people, pPeople));
            Console.WriteLine();
            Console.WriteLine("List of People: ");
            em.Show(people);
            Console.WriteLine();
            Console.WriteLine(people[0].ToString());
            Console.WriteLine(people[3].ToString());
            Console.WriteLine(people[4].ToString());
        }
    }
}
