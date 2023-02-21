using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab03TPP.lab03;
using System;
using lab03TPP.Classes;

namespace TestProject1
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Stack to be used in the test
        /// </summary>
        private Stack stack;
        private Person p1;
        private Person p2;
        private Person p3;
        private Person p4;
        private Person p5;

        /// <summary>
        /// Initializing the stack to be use on each test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            this.stack = new Stack(5);
            p1 = new Person("Pepe", "Rodríguez", "Pérez", "75836574I");
            p2 = new Person("Paco", "Rodríguez", "Peláez", "75836575J");
            p3 = new Person("José", "Martínez", "Pérez", "75836576K");
            p4 = new Person("Carlos", "Asenjo", "Pérez", "75836577L");
            p5 = new Person("Jorge", "Eustaquio", "Núñez", "75836578M");
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

            this.stack = new Stack(5);

            Assert.IsTrue(stack.isEmpty, "Should be empty");
            stack.Push(p1);
            stack.Push(p2);
            stack.Push(p3);
            Assert.IsFalse(stack.isEmpty, "Should not be empty");
            stack.Push(p4);
            stack.Push(p5);
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

            this.stack = new Stack(5);

            stack.Push(p1);
            stack.Push(p2);
            stack.Push(p3);
            stack.Push(p4);
            stack.Push(p5);
            Assert.IsTrue(stack.isFull, "Should be full");
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            Assert.IsTrue(stack.isEmpty, "Shoud be emmpty");
            Assert.AreEqual(0, stack.NumberOfElements);
        }

        // With integers and Employees

        /// <summary>
        /// Testing if the condition of being full is throwing the exception correctly
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPushConditionsIsFull()
        {
            foreach(Employee e in Code.CreateEmployees())
            {
                stack.Push(e);
            }
        }

        /// <summary>
        /// Testing if the push of a null object is throwing the exception correctly
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPushConditionsNullObject()
        {
            Object nObject = null;
            stack.Push(nObject);
        }

        /// <summary>
        /// Test if the pop when the list is empty is throwig the exception correctly
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPopConditions()
        {
            stack.Push(1);
            stack.Pop();
            Assert.IsTrue(stack.isEmpty);
            stack.Pop();
        }

        // With people

        /// <summary>
        /// Testing if the condition of being full is throwing the exception correctly
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPushConditionsIsFullP()
        {
            stack = new Stack(2);
            stack.Push(p1);
            stack.Push(p2);
            stack.Push(p3);
        }

        /// <summary>
        /// Testing if the push of a null object is throwing the exception correctly
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPushConditionsNullObjectP()
        {
            Person nPerson = null;
            stack.Push(nPerson);
        }

        /// <summary>
        /// Test if the pop when the list is empty is throwig the exception correctly
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPopConditionsP()
        {
            stack.Push(p1);
            stack.Pop();
            Assert.IsTrue(stack.isEmpty);
            stack.Pop();
        }
    }
}
