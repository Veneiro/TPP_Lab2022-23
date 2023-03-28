using lab02TPP;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TPP.MoviesExam;

namespace SampleExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var i = 0;
            WhileLoop(() => i < 10, () => {
                Console.WriteLine(i);
                i = i + 1;
            });

            SinglyLinkedList<double> list1 = new SinglyLinkedList<double>();
            SinglyLinkedList<double> list2 = new SinglyLinkedList<double>();

            for (var c = 0; c < 4; c++)
            {
                list1.Add(new Random().NextDouble());
                list2.Add(new Random().NextDouble());
            }

            Console.WriteLine(Euclidean(list1, list2));

            SinglyLinkedList<double> list3 = new SinglyLinkedList<double>();
            list3.Add(3);
            list3.Add(4);
            list3.Add(2);
            list3.Add(4);
            list3.Add(5);
            list3.Add(6);

            Console.WriteLine(list3.ReduceRange<double,double>((res, a)=>res = res + a, 1, 3));

            MovieModel model = new MovieModel();

            Console.WriteLine(model.FilmsByFormatAndGenre("HD", "Comedy"));

            model.MostAwardedPrize();
        }

        static void For(Func<bool> condition, Action body, Action actualizar)
        {
            if (condition())
            {
                body();
                actualizar();
                For(condition, body, actualizar); // recursion to iterate
            }
        }

        static void WhileLoop(Func<bool> condition, Action body)
        {
            if(condition())
            {
                body();
                WhileLoop(condition, body);
            }
        }

        static double Euclidean(SinglyLinkedList<double> list1, SinglyLinkedList<double> list2)
        {
            var resToSquare = 0.0;

            for(var i = 0; i < list1.Count(); i++)
            {
                resToSquare = resToSquare + Math.Pow(list1.GetElement(i) - list2.GetElement(i), 2);
            }

            return Math.Sqrt(resToSquare);
        }
    }
}
