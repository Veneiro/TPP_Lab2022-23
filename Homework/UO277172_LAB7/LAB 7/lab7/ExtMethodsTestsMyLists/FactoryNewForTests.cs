using System;
using System.Linq;
using System.Diagnostics;
using PolymorphicSimplyLinkedList;
using TPP.Laboratory.ObjectOrientation.Lab03;

namespace TPP.Laboratory.Functional.Lab05 {

    /// <summary>
    /// Creates collections of objects 
    /// </summary>
    public class FactoryNewForTests {

        /// <summary>
        /// Creats a collection of people
        /// </summary>
        public static List<Person> CreatePeopleList()
        {
            string[] firstNames = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina", "María", "Juan" };
            string[] surnames = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez", "Díaz", "Hevia" };
            string[] idNumbers = { "9876384A", "103478387F", "23476293R", "4837649A", "67365498B", "98673645T", "56837645F", "87666354D", "9376384K" };

            Debug.Assert(firstNames.Length == surnames.LongLength && surnames.Length == idNumbers.Length);
            List<Person> people = new LinkedList<Person>();
            for (int i = 0; i < firstNames.Length - 1; i++)
                people.Add(new Person(firstNames[i], surnames[i], idNumbers[i]));
            return people;
        }


        /// <summary>
        /// Creates a collection of angles from 0 to 360 degrees
        /// </summary>
        public static List<Angle> CreateAnglesList()
        {
            List<Angle> angles = new LinkedList<Angle>();
            for (int angle = 0; angle <= 360; angle++)
                angles.Add(new Angle(angle / 180.0 * Math.PI));
            return angles;
        }

    }
}
