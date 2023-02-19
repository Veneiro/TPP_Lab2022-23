using NUnit.Framework;
using System.Collections;

namespace TestProject
{
    public class Tests
    {
        private Stack stack;

        [SetUp]
        public void Setup()
        {
            this.stack = new Stack(5);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}