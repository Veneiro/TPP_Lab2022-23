using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTP_HW_5;
using System;
using System.Linq;

namespace ExtensionMethodsTests
{
    [TestClass]
    public class ExtensionMethodsTests
    {
        Angle[] angles;
        Person[] people;
        Functions em;

        [TestInitialize]
        public void InitializeTests()
        {
            // * We create an empty stack
            this.angles = Factory.CreateAngles();
            this.people = Factory.CreatePeople();
            em = new Functions();
        }

        [TestMethod]
        public void FindTests()
        {
            Assert.AreEqual(em.Find(angles, angRad => angRad.Quadrant == 1), angles[0]);
            Assert.AreEqual(em.Find(people, person => (person.Name[person.Name.Length - 1] == 'a'
                                    || person.Id[person.Id.Length - 1] == 'A')), people[0]);
        }

        [TestMethod]
        public void FilterTests()
        {
            Person p = people[0];
            Predicate<Person> pPeople = (person => (person.Name[person.Name.Length - 1] == 's'
                                        || person.Id[person.Id.Length - 1] == 'A'));
            var aux = em.Filter(people, pPeople);
            Assert.AreEqual(aux[0], p);

            Predicate<Angle> pAngle = a => a.Quadrant == 1;
            var aux2 = em.Filter(angles, pAngle);
            Assert.AreEqual(aux2[0], angles[0]);
        }

        [TestMethod]
        public void ReduceTest()
        {
            Assert.AreEqual(em.Reduce<Person, int>(people, (x, y) => GetMaxFirstNameLength(x, y)), people[9]);
            Assert.AreEqual(em.Reduce<Angle, int>(angles, (x, y) => GetMaxRadians(x, y)), angles[angles.Length - 1]);
        }

        private Person GetMaxFirstNameLength(Person x, Person y)
        {
            if (x.Name.Length > y.Name.Length)
            {
                return x;
            }
            else
            {
                return y;
            }
        }

        private Angle GetMaxRadians(Angle x, Angle y)
        {
            if (x.Radians > y.Radians)
            {
                return x;
            }
            else
            {
                return y;
            }
        }
    }
}
