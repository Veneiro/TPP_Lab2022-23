using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPP.Laboratory.ObjectOrientation.Lab03;

namespace StackTests
{
    [TestClass]
    public class StackTests
    {
        /// <summary>
        /// Instance used in most of the tests
        /// </summary>
        private Stack stack; 

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
            // * We create an empty stack
            this.stack = new Stack(1);
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
            Assert.AreEqual(1, this.stack.MaxSize);  // 1st expected value, 2nd actual value
        }

        /// <summary>
        /// Test of Add and GetElement
        /// </summary>
        [TestMethod]
        public void PushTest()
        {
            const uint firstValue = 3, secondValue = 8;
            this.stack.Push(firstValue);
            Assert.AreEqual(false, this.stack.IsFull);
            Assert.AreEqual(false, this.stack.IsEmpty);
            this.stack.Push(secondValue);
            Assert.AreEqual(true, this.stack.IsFull);
        }

        /// <summary>
        /// Test of Add and SetElement
        /// </summary>
        [TestMethod]
        public void PopElementTest()
        {
            const uint firstValue = 3, secondValue = 8;
            this.stack.Push(firstValue);
            this.stack.Push(secondValue);
            this.stack.Pop();
            Assert.AreEqual(false, this.stack.IsFull);
        }

        ///// <summary>
        ///// Test that checks that GetElement controls the access out of bounds.
        ///// The ExpectedException attribute (annotation) checks that the exception
        ///// specified as a parameter (ArgumentException) is thrown.
        ///// Otherwise, the test is wrong.
        ///// </summary>
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void GetElementOutOfBoundsTest()
        //{
        //    this.stack.GetElement(0);
        //}

        ///// <summary>
        ///// Test that checks that SetElement controls the access out of bounds.
        ///// </summary>
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void SetElementOutOfBoundsTest()
        //{
        //    this.stack.Add(0);
        //    this.stack.SetElement(1, 0);
        //}

    //}
}
}
