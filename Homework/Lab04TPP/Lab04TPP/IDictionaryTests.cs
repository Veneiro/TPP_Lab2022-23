using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TPP.Laboratory.ObjectOrientation.Lab03;

namespace vector
{
    [TestClass]
    public class IDictionaryTests
    {
        /// <summary>
        /// Instance used in most of the tests
        /// </summary>
        IDictionary<string, Person> list;

        /********************** Special semantics testing methods *********************************/


        /// <summary>
        /// This class (static) method is run only once, before running any test.
        /// Used for initialization purposes to assign the resoures used by all the tests in this class.
        /// The attribute (annotation) between [] allows using any static method with any name.
        /// It is not necessary to be written if it is not used.
        /// </summary>
        [ClassInitialize]
        public static void InitializeAllTheTests(TestContext testContext)
        {
        }

        /// <summary>
        /// Method that executed before each single test in this class.
        /// Used to initialize all the tests in the class.
        /// The attribute (annotation) between [] allows using any static method with any name.
        /// It is not necessary to be written if it is not used.
        /// </summary>
        [TestInitialize]
        public void InitializeTests()
        {
            this.list = new Dictionary<string, Person>();
        }

        /// <summary>
        /// Method that executed after each single test in this class.
        /// Used to clean up all the tests in the class.
        /// The attribute (annotation) between [] allows using any static method with any name.
        /// It is not necessary to be written if it is not used.
        /// </summary>
        [TestCleanup]
        public void CleanUpTests()
        {
        }

        /// <summary>
        /// This class (static) method is run only once, after running all the tests.
        /// Used for cleaning up purposes, to release the resources used by all the tests in this class.
        /// The attribute (annotation) between [] allows using any static method with any name.
        /// It is not necessary to be written if it is not used.
        /// </summary>
        [ClassCleanup]
        public static void CleanUpAllTheTests()
        {
        }

        /********************** Tesing methods *********************************/

        /// <summary>
        /// The public methods with the TestMethod attribute (annotation) are executed as unit tests
        /// </summary>
        [TestMethod]
        public void ConstructorStackTest()
        {
            // * The is called in the InitializeTests method
            // * The static methods of the Assert class are used to assert those conditions
            //   that must be true if the code is correct
            Assert.AreEqual(0, this.list.Count);  // 1st expected value, 2nd actual value
        }

        /// <summary>
        /// Test of Add
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            Person p1 = new Person("Pedro", "Rodríguez", "67385462H"), p2 = new Person("Roberta", "Pérez", "67482462R");
            this.list.Add(p1.IDNumber, p1);
            Assert.AreEqual(1, list.Count);
            this.list.Add(p2.IDNumber, p2);
            Assert.AreEqual(2, list.Count);
        }

        /// <summary>
        /// Test of NumberOfElements
        /// </summary>
        [TestMethod]
        public void NumberOfElementsTest()
        {
            Person p1 = new Person("Pedro", "Rodríguez", "67385462H"), p2 = new Person("Roberta", "Pérez", "67482462R");
            this.list.Add(p1.IDNumber, p1);
            this.list.Add(p2.IDNumber, p2);
            this.list.Remove(p1.IDNumber);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test of the Get Element
        /// </summary>
        [TestMethod]
        public void GetElementsTest()
        {
            Person p1 = new Person("Pedro", "Rodríguez", "67385462H"), p2 = new Person("Roberta", "Pérez", "67482462R");
            this.list.Add(p1.IDNumber, p1);
            this.list.Add(p2.IDNumber, p2);
            //Assert.AreEqual(list., list.);
        }

        /// <summary>
        /// Test of Consult Existance
        /// </summary>
        [TestMethod]
        public void ConsultExistanceTest()
        {
            Person p1 = new Person("Pedro", "Rodríguez", "67385462H"), p2 = new Person("Roberta", "Pérez", "67482462R");
            this.list.Add(p1.IDNumber, p1);
            this.list.Add(p2.IDNumber, p2);
            Assert.AreEqual(true, list.ContainsKey(p1.IDNumber));
        }

        /// <summary>
        /// Test of Get Index
        /// </summary>
        [TestMethod]
        public void GetIndexTest()
        {
            Person p1 = new Person("Pedro", "Rodríguez", "67385462H"), p2 = new Person("Roberta", "Pérez", "67482462R");
            this.list.Add(p1.IDNumber, p1);
            this.list.Add(p2.IDNumber, p2);
            Assert.AreEqual(true, list.TryGetValue(p1.IDNumber, out p1));
        }

        /// <summary>
        /// Test of Delete
        /// </summary>
        [TestMethod]
        public void DeleteTest()
        {
            Person p1 = new Person("Pedro", "Rodríguez", "67385462H"), p2 = new Person("Roberta", "Pérez", "67482462R");
            this.list.Add(p1.IDNumber, p1);
            this.list.Add(p2.IDNumber, p2);
            this.list.Remove(p1.IDNumber);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test of the foreach loop
        /// </summary>
        [TestMethod]
        public void LoopTest()
        {
            Person p1 = new Person("Pedro", "Rodríguez", "67385462H"), p2 = new Person("Roberta", "Pérez", "67482462R");
            this.list.Add(p1.IDNumber, p1);
            this.list.Add(p2.IDNumber, p2);

            string[] aux = new string[2];
            int counter = 0;
            foreach(var i in list)
            {
                aux[counter] = i.Key;
                counter++;
            }

            Assert.AreEqual(p1.IDNumber, aux[0]);
            Assert.AreEqual(p2.IDNumber, aux[1]);
        }
    }
}
