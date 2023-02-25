using NUnit.Framework;
using lab02TPP;

namespace lab02TPP_Testing
{
    public class Tests
    {
        SinglyLinkedList exampleList;
        [SetUp]
        public void Setup()
        {
            exampleList = new SinglyLinkedList();
        }

        [Test]
        public void TestAdd()
        {
            exampleList.Add(1);
            Assert.IsTrue(exampleList.Contains(1));
        }

        [Test] 
        public void TestRemove()
        {
            exampleList.Add(1);
            int i = exampleList.GetElement(0);
            exampleList.Remove(0);
            Assert.IsFalse(exampleList.Contains(i));
        }

        [Test]
        public void TestContains()
        {
            exampleList.Add(1);
            Assert.IsTrue(exampleList.Contains(1));
        }

        [Test]
        public void TestGetElement() 
        {
            exampleList.Add(1);
            Assert.That(1 == exampleList.GetElement(0));
        }
    }
}