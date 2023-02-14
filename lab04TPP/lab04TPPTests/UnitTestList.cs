using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace lab04TPPTests
{
    public class UnitTestList
    {
        IList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new List<int>();
        }

        [Test]
        public void Test1()
        {
            list.Add(1);
            list.Add(2);

            int i = list.Count;

            Assert.AreEqual(i, 2);
        }

        [Test] public void Test2()
        {

        }
    }
}