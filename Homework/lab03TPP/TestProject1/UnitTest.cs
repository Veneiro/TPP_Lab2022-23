using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab03TPP.lab03;
using System;

namespace TestProject1
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Stack to be used in the test
        /// </summary>
        private Stack stack;

        /// <summary>
        /// Initializing the stack to be use on each test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            this.stack = new Stack(5);
        }

        /// <summary>
        /// Testing push method
        /// </summary>
        [TestMethod]
        public void TestPush()
        {
            Assert.IsTrue(stack.isEmpty, "Should be empty");
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.IsFalse(stack.isEmpty, "Should not be empty");
            stack.Push(4);
            stack.Push(5);
            Assert.IsTrue(stack.isFull);
            Assert.AreEqual(5, stack.NumberOfElements);
        }

        /// <summary>
        /// Testing pop method
        /// </summary>
        [TestMethod]
        public void TestPop()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Assert.IsTrue(stack.isFull, "Should be full");
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            Assert.IsTrue(stack.isEmpty, "Shoud be emmpty");
            Assert.AreEqual(0, stack.NumberOfElements);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPushConditionsIsFull()
        {
            foreach(Employee e in Code.CreateEmployees())
            {
                stack.Push(e);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPushConditionsNullObject()
        {
            Object nObject = null;
            stack.Push(nObject);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPopConditions()
        {
            stack.Push(1);
            stack.Pop();
            Assert.IsTrue(stack.isEmpty);
            stack.Pop();
        }
    }
}
