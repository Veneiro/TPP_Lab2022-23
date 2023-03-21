using ClassLibrary;
using lab02TPP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SinglyLinkedList<int> ints= new SinglyLinkedList<int>();
            for(var i = 0; i <= 20; i++)
            {
                ints.Add(i);
            }
            int counter = 0;
            IEnumerable<int> list = ints.RangeCount(10, 20, ref counter);
            Assert.AreEqual(9, counter);
        }
    }
}
