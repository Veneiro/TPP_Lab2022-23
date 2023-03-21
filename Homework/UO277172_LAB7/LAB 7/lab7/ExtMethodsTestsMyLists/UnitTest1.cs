using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolymorphicSimplyLinkedList;
using System;
using algorithms;
using TPP.Laboratory.ObjectOrientation.Lab03;
using TPP.Laboratory.Functional.Lab05;

namespace ExtensionMethodsMyListsTests
{
    [TestClass]
    public class UnitTest1
    {
        List<Angle> angles = new LinkedList<Angle>();
        List<Person> people = new LinkedList<Person>();

        [TestInitialize]
        public void InitializeTests()
        {
            // * We create an empty stack
            //this.angles = FactoryNewForTests.CreateAnglesList();
            //this.people = FactoryNewForTests.CreatePeopleList();

            string[] firstNames = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina", "María", "Juan" };
            string[] surnames = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez", "Díaz", "Hevia" };
            string[] idNumbers = { "9876384A", "103478387F", "23476293R", "4837649A", "67365498B", "98673645T", "56837645F", "87666354D", "9376384K" };

            for (int i = 0; i < firstNames.Length - 1; i++)
                people.Add(new Person(firstNames[i], surnames[i], idNumbers[i]));

            for (int angle = 0; angle <= 360; angle++)
                angles.Add(new Angle(angle / 180.0 * Math.PI));

        }

        [TestMethod]
        public void FindTests()
        {
            Assert.AreEqual(angles.Find(angles, angRad => angRad.Quadrant == 1), angles.GetElement(0));
            Assert.AreEqual(people.Find(people, person => (person.FirstName[person.FirstName.Length - 1] == 'a'
                                    || person.IDNumber[person.IDNumber.Length - 1] == 'A')), people.GetElement(0));
        }

        [TestMethod]
        public void FilterTests()
        {
            Person p = people.GetElement(0);
            Predicate<Person> pPeople = (person => (person.FirstName[person.FirstName.Length - 1] == 's'
                                        || person.IDNumber[person.IDNumber.Length - 1] == 'A'));
            List<Person> aux = people.Filter<Person>(people, pPeople);
            Assert.AreEqual(aux.GetElement(0), p);

            Predicate<Angle> pAngle = a => a.Quadrant == 1;
            List<Angle> aux2 = angles.Filter<Angle>(angles, pAngle);
            Assert.AreEqual(aux2.GetElement(0), angles.GetElement(0));
        }

        [TestMethod]
        public void ReduceTest()
        {
            float aux = 100;
            Assert.AreEqual(people.Reduce<Person, Person>(new Person("", "", ""), people, (x, y) => GetMaxFirstNameLength(x, y)), people.GetElement(6));
            Assert.AreEqual(angles.Reduce<Angle, double>(aux, angles, (x, y) => GetMaxRadians(x, y)), 100);
            Assert.AreEqual(angles.Reduce<Angle, float>(aux, angles, (x, y) => GetDegreeSum(angles)), 64980);
        }

        private float GetDegreeSum(List<Angle> angles)
        {
            float ang = 0;
            foreach (var a in angles)
            {
                ang += a.Degrees;
            }
            return ang;
        }

        private Person GetMaxFirstNameLength(Person x, Person y)
        {
            if (x.FirstName.Length > y.FirstName.Length)
            {
                return x;
            }
            else
            {
                return y;
            }
        }

        private double GetMaxRadians(double x, Angle y)
        {
            if (x < y.Radians)
            {
                x = y.Radians;
                return x;
            }
            else
            {
                return x;
            }
        }
    }
}
