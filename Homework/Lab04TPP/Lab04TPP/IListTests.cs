using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace vector
{
    [TestClass]
    public class IListTests
    {
        /// <summary>
        /// Instance used in most of the tests
        /// </summary>
        IList<int> list;

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
            this.list = new List<int>();
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
            const int firstValue = 3, secondValue = 8;
            this.list.Add(firstValue);
            Assert.AreEqual(1, list.Count);
            this.list.Add(secondValue);
            Assert.AreEqual(2, list.Count);
        }

        /// <summary>
        /// Test of Number Of Elements
        /// </summary>
        [TestMethod]
        public void NumberOfElementsTest()
        {
            const int firstValue = 3, secondValue = 8;
            this.list.Add(firstValue);
            this.list.Add(secondValue);
            this.list.Remove(secondValue);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test of GetElement
        /// </summary>
        [TestMethod]
        public void GetElementsTest()
        {
            const int firstValue = 3, secondValue = 8;
            this.list.Add(firstValue);
            this.list.Add(secondValue);
            Assert.AreEqual(0, list.IndexOf(3));
        }

        /// <summary>
        /// Tests of Consult Existance
        /// </summary>
        [TestMethod]
        public void ConsultExistanceTest()
        {
            const int firstValue = 3, secondValue = 8;
            this.list.Add(firstValue);
            this.list.Add(secondValue);
            Assert.AreEqual(true, list.Contains(3));
        }

        /// <summary>
        /// Test of Get Index
        /// </summary>
        [TestMethod]
        public void GetIndexTest()
        {
            const int firstValue = 3, secondValue = 8;
            this.list.Add(firstValue);
            this.list.Add(secondValue);
            Assert.AreEqual(0, list.IndexOf(3));
        }

        /// <summary>
        /// Test of Delete
        /// </summary>
        [TestMethod]
        public void DeleteTest()
        {
            const int firstValue = 3, secondValue = 8;
            this.list.Add(firstValue);
            this.list.Add(secondValue);
            this.list.Remove(secondValue);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test of the foreach loop
        /// </summary>
        [TestMethod]
        public void LoopTest()
        {
            const int firstValue = 3, secondValue = 8;
            this.list.Add(firstValue);
            this.list.Add(secondValue);

            int[] aux = new int[2];
            int counter = 0;
            foreach(int i in list)
            {
                aux[counter] = i;
                counter++;
            }

            Assert.AreEqual(3, aux[0]);
            Assert.AreEqual(8, aux[1]);
        }
    }
}
