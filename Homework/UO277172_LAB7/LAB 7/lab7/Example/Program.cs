using PolymorphicSimplyLinkedList;
using System;
using TPP.Laboratory.ObjectOrientation.Lab03;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Angle> angles = new LinkedList<Angle>();
            List<Person> people = new LinkedList<Person>();
            List<int> inte = new LinkedList<int>();
            string[] firstNames = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina", "María", "Juan" };
            string[] surnames = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez", "Díaz", "Hevia" };
            string[] idNumbers = { "9876384A", "103478387F", "23476293R", "4837649A", "67365498B", "98673645T", "56837645F", "87666354D", "9376384K" };

            for (int i = 0; i < firstNames.Length - 1; i++)
                people.Add(new Person(firstNames[i], surnames[i], idNumbers[i]));

            for (int angle = 0; angle <= 360; angle++)
                angles.Add(new Angle(angle / 180.0 * Math.PI));

            for(int i = 0; i <= 10; i++)
            {
                inte.Add(i);
            }

            foreach(int elem in inte)
            {
                Console.WriteLine(elem.ToString());
            }

            foreach(Person elem in people)
            {
                  Console.WriteLine(elem.ToString());
            }

            foreach (var elem in angles)
            {
                Console.WriteLine(elem.ToString());
            }

            Console.WriteLine((angles.Find(angles, angRad => angRad.Quadrant == 0)).ToString());
        }
    }
}
