using Classes;
using PTP_HW_5;
using System;
using System.Diagnostics;
using System.Numerics;

namespace Lab05TPP
{
    internal class ProgramCopy
    {
        static void Main(string[] args)
        {
            // Variables
            Person[] people = Factory.CreatePeople();
            Angle[] angles = Factory.CreateAngles();
            Functions f = new Functions();
            FunctionsCopy fc = new FunctionsCopy();

            // Functions
            var resFindP = f.Find<Person>(people, x => x.Name.Equals("Michael")); // Search a person named Michael
            var resFindA = f.Find<Angle>(angles, x => x.Degrees.Equals(90)); // Searching a 90º angle
            var resFilterP = f.Filter<Person>(people, x => x.Name.Equals("James")); // Searching people named James
            var resFilterA = f.Filter<Angle>(angles, x => x.Degrees.Equals(90)); // Searching all the 90º angle
            // var resReduceP = 
            float resReduceA = f.Reduce<Angle, float>(angles, (r, d) => r += d.Degrees);

            // Checkings
            Console.WriteLine("Find Method\n".ToUpper());

            Debug.Assert(resFindP.Equals(people[6]), "The result person is not the one we were searching");
            Console.WriteLine(resFindP.ToString() + "\n");

            Console.WriteLine(resFindA.ToString() + "\n");

            Console.WriteLine("---------------------------------\n");

            Console.WriteLine("Filter Method\n".ToUpper());

            Debug.Assert(resFilterP.Count == 3, "We didn't filter correctly, the result is not the expected");
            foreach (Person person in resFilterP)
                Console.WriteLine(person.ToString());

            Console.WriteLine();

            foreach (Angle a in resFilterA)
                Console.WriteLine(a.ToString());

            Console.WriteLine();
            
            Console.WriteLine("Total Angle degrees: ", resReduceA);

            Console.WriteLine("---------------------------------\n");

            var res = fc.Map<Person, string>(people, p => p.Surname + ", " + p.Name);
            foreach (var e in res) 
                Console.WriteLine(e.ToString());

            Console.WriteLine("---------------------------------\n");

            fc.Show<Person>(people, x => Console.WriteLine(x));

        }
    }
}
