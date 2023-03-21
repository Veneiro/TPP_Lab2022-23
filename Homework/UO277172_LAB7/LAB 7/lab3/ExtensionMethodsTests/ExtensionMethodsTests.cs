using delegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolymorphicSimplyLinkedList;
using System;
using TPP.Laboratory.Functional.Lab05;

namespace ExtensionMethodsTests
{
    [TestClass]
    public class ExtensionMethodsTests
    {
        Angle[] angles;
        Person[] people;
        ExtensionMethods em;

        [TestInitialize]
        public void InitializeTests()
        {
            // * We create an empty stack
            this.angles = Factory.CreateAngles();
            this.people = Factory.CreatePeople();
            em = new ExtensionMethods();
        }

        [TestMethod]
        public void FindTests()
        {
            Assert.AreEqual(em.Find(angles, angRad => angRad.Quadrant == 1), angles[0]);
            Assert.AreEqual(em.Find(people, person => (person.FirstName[person.FirstName.Length - 1] == 'a' 
                                    || person.IDNumber[person.IDNumber.Length - 1] == 'A')), people[0]);
        }

        [TestMethod]
        public void FilterTests()
        {
            Person p = people[0];
            Predicate<Person> pPeople = (person => (person.FirstName[person.FirstName.Length - 1] == 's' 
                                        || person.IDNumber[person.IDNumber.Length - 1] == 'A'));
            Person[] aux = em.Filter(people, pPeople);
            Assert.AreEqual(aux[0], p);

            Predicate<Angle> pAngle = a => a.Quadrant == 1;
            Angle[] aux2 = em.Filter(angles, pAngle);
            Assert.AreEqual(aux2[0], angles[0]);
        }

        [TestMethod]
        public void ReduceTest()
        {
            float aux = 100;
            Assert.AreEqual(em.Reduce<Person, Person>(new Person("","",""), people, (x, y) => GetMaxFirstNameLength(x,y)), people[6]);
            Assert.AreEqual(em.Reduce<Angle, double>(aux, angles, (x, y) => GetMaxRadians(x, y)), 100);
            Assert.AreEqual(em.Reduce<Angle, float>(aux, angles, (x, y) => GetDegreeSum(angles)), 64980);
        }

        private float GetDegreeSum(Angle[] angles)
        {
            float ang = 0;
            foreach(var a in angles)
            {
                ang += a.Degrees;
            }
            return ang;
        }

        private Person GetMaxFirstNameLength(Person x, Person y)
        {
            if(x.FirstName.Length > y.FirstName.Length)
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
            if(x < y.Radians)
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
