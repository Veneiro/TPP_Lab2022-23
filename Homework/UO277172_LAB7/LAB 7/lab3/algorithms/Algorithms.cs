
using algorithms;
using System;
using System.Collections.Generic;

namespace TPP.Laboratory.ObjectOrientation.Lab03 {

    class Algorithms {

        // Exercise: Implement an IndexOf method that finds the first position (index) 
        // of an object in an array of objects. It should be valid for Person, Angle and future classes.
        public static int IndexOf<T>(T[] list, T element)
        {
            for(int i = 0; i < list.Length; i++)
            {
                if (element.Equals(list[i]))
                {
                    return i;
                }
            }
            Console.WriteLine("Element not found");
            return -1;
        }

        public static List<int> IndexOfComp<T>(T[] list, T element, IComparator<T> comparator)
        {
            List<int> elements = new List<int>();
            for (int i = 0; i < list.Length; i++)
            {
                if (comparator.Compare(element, list[i]))
                {
                    elements.Add(i);
                }
            }
            return elements;
        }

        static Person[] CreatePeople() {
            string[] firstnames = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina" };
            string[] surnames = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez" };
            int numberOfPeople = 100;

            Person[] printOut = new Person[numberOfPeople];
            Random random = new Random();
            for (int i = 0; i < numberOfPeople; i++)
                printOut[i] = new Person(
                    firstnames[random.Next(0, firstnames.Length)],
                    surnames[random.Next(0, surnames.Length)],
                    random.Next(9000000, 90000000) + "-" + (char)random.Next('A', 'Z')
                    );
            return printOut;
        }

        static Angle[] CreateAngles() {
            Angle[] angles = new Angle[(int)(Math.PI * 2 * 10)];
            int i = 0;
            while (i < angles.Length) {
                angles[i] = new Angle(i / 10.0);
                i++;
            }
            return angles;
        }

        static void Main() {
            var people = CreatePeople();
            var angles = CreateAngles();

            Console.WriteLine(IndexOf(people, people[40]));
            Console.WriteLine(IndexOf(people, new Person(people[40].FirstName, people[40].SurName, people[40].IDNumber)));

            Console.WriteLine(IndexOf(angles, angles[40]));
            Console.WriteLine(IndexOf(angles, new Angle(angles[40].Radians)));

            Console.WriteLine("Index of people with the same name as " + people[40].FirstName + ":");
            List<int> res = IndexOfComp(people, people[40], new PersonByNameComparator());
            String aux = "";
            foreach(int i in res)
            {
                aux += i + " - ";
            }
            Console.WriteLine(aux);

            Console.WriteLine("Index of angles in the same quadrant as angle with " + angles[40].Degrees + "degrees:");
            List<int> res2 = IndexOfComp(angles, angles[40], new AnglesInTheSameQuadrantComparator());
            String aux2 = "";
            foreach (int i in res2)
            {
                aux2 += i + " - ";
            }
            Console.WriteLine(aux2);
        }

    }

}
