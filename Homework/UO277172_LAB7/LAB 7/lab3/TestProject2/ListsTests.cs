using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolymorphicSimplyLinkedList;
using System;

namespace TestProject2
{
    /// <summary>
    /// Class to test the Vector class
    ///</summary>
    [TestClass]
    public class ListsTests
    {

        /// <summary>
        /// Instance used in most of the tests
        /// </summary>
        private LinkedList<string> listString;
        private LinkedList<int> listInt;
        private LinkedList<double> listDouble;

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
            // * We create an empty vector
            this.listString = new LinkedList<string>();
            this.listInt = new LinkedList<int>();
            this.listDouble = new LinkedList<double>();
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
        public void ConstructorVectorTest()
        {
            // * The is called in the InitializeTests method
            // * The static methods of the Assert class are used to assert those conditions
            //   that must be true if the code is correct
            Assert.AreEqual(0, this.listString.Size());  // 1st expected value, 2nd actual value
            Assert.AreEqual(0, this.listInt.Size());
            Assert.AreEqual(0, this.listDouble.Size());
        }

        /// <summary>
        /// Test of Add and GetElement
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            const int firstValueInt = 3, secondValueInt = -8;
            this.listInt.Add(firstValueInt);
            Assert.AreEqual(1, this.listInt.Size());
            Assert.AreEqual(firstValueInt, this.listInt.GetElement(0));
            this.listInt.Add(secondValueInt);
            Assert.AreEqual(2, this.listInt.Size());
            Assert.AreEqual(secondValueInt, this.listInt.GetElement(1));

            const string firstValueString = "hello", secondValueString = "bye";
            this.listString.Add(firstValueString);
            Assert.AreEqual(1, this.listString.Size());
            Assert.AreEqual(firstValueString, this.listString.GetElement(0));
            this.listString.Add(secondValueString);
            Assert.AreEqual(2, this.listString.Size());
            Assert.AreEqual(secondValueString, this.listString.GetElement(1));

            const double firstValueDouble = 3.15, secondValueDouble = -4.56;
            this.listDouble.Add(firstValueDouble);
            Assert.AreEqual(1, this.listDouble.Size());
            Assert.AreEqual(firstValueDouble, this.listDouble.GetElement(0));
            this.listDouble.Add(secondValueDouble);
            Assert.AreEqual(2, this.listDouble.Size());
            Assert.AreEqual(secondValueDouble, this.listDouble.GetElement(1));
        }

        /// <summary>
        /// Test of Add and SetElement
        /// </summary>
        [TestMethod]
        public void SetElementTest()
        {
            this.listInt.Add(0);
            this.listInt.Add(2);
            const int firstValue = 3, secondValue = -8;
            this.listInt.Set(0, firstValue);
            this.listInt.Set(1, secondValue);
            Assert.AreEqual(firstValue, this.listInt.GetElement(0));
            Assert.AreEqual(secondValue, this.listInt.GetElement(1));

            this.listString.Add("olleh");
            this.listString.Add("eyb");
            const string firstValueString = "hello", secondValueString = "bye";
            this.listString.Set(0, firstValueString);
            this.listString.Set(1, secondValueString);
            Assert.AreEqual(firstValueString, this.listString.GetElement(0));
            Assert.AreEqual(secondValueString, this.listString.GetElement(1));

            this.listDouble.Add(0.01);
            this.listDouble.Add(2.01);
            const double firstValueDouble = 3.15, secondValueDouble = -4.56;
            this.listDouble.Set(0, firstValueDouble);
            this.listDouble.Set(1, secondValueDouble);
            Assert.AreEqual(firstValueDouble, this.listDouble.GetElement(0));
            Assert.AreEqual(secondValueDouble, this.listDouble.GetElement(1));
        }

        /// <summary>
        /// Test that checks that GetElement controls the access out of bounds.
        /// The ExpectedException attribute (annotation) checks that the exception
        /// specified as a parameter (ArgumentException) is thrown.
        /// Otherwise, the test is wrong.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetElementOutOfBoundsTest()
        {
            this.listInt.GetElement(0);
            this.listString.GetElement(0);
            this.listDouble.GetElement(0);
        }

        /// <summary>
        /// Test that checks that SetElement controls the access out of bounds.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetElementOutOfBoundsTest()
        {
            this.listInt.Add(0);
            this.listInt.Set(1, 0);
            this.listString.Add("bye");
            this.listString.Set(1, "hello");
            this.listDouble.Add(0.1);
            this.listDouble.Set(1, 0.2);
        }
    }
}
