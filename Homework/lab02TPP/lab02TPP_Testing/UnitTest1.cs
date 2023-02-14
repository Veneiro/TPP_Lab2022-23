using NUnit.Framework;
using lab02TPP;
using P;

namespace lab02TPP_Testing
{
    public class Tests
    {
        SinglyLinkedList exampleList;
        int i;
        double d;
        string s;
        Person p;
        [SetUp]
        public void Setup()
        {
            exampleList = new SinglyLinkedList();
            p = new Person("Pepe", "Rodriguez", "Alvarez", "37645286P");
            i = 1;
            d = 1.1;
            s = "Hola";
        }

        [Test]
        public void TestAdd()
        {
            exampleList.Add(this.s);
            Assert.IsTrue(exampleList.Contains(this.s));
            
            exampleList.Add(this.p);
            Assert.IsTrue(exampleList.Contains(this.p));

            exampleList.Add(this.d);
            Assert.IsTrue(exampleList.Contains(this.d));

            exampleList.Add(this.i);
            Assert.IsTrue(exampleList.Contains(this.i));

        }

        [Test] 
        public void TestRemove()
        {
            exampleList.Add(this.i);
            int aux = (int)exampleList.GetElement(0);
            exampleList.Remove(0);
            Assert.IsFalse(exampleList.Contains(aux));

            exampleList.Add(this.p);
            Person aux2 = (Person)exampleList.GetElement(0);
            exampleList.Remove(0);
            Assert.IsFalse(exampleList.Contains(aux));

            exampleList.Add(this.s);
            string aux3 = (string)exampleList.GetElement(0);
            exampleList.Remove(0);
            Assert.IsFalse(exampleList.Contains(aux));

            exampleList.Add(this.d);
            double aux4 = (double)exampleList.GetElement(0);
            exampleList.Remove(0);
            Assert.IsFalse(exampleList.Contains(aux));

        }

        [Test]
        public void TestContains()
        {
            exampleList.Add(this.i);
            Assert.IsTrue(exampleList.Contains(this.i));

            exampleList.Add(this.d);
            Assert.IsTrue(exampleList.Contains(this.d));

            exampleList.Add(this.p);
            Assert.IsTrue(exampleList.Contains(this.p));

            exampleList.Add(this.s);
            Assert.IsTrue(exampleList.Contains(this.s));
        }

        [Test]
        public void TestGetElement() 
        {
            exampleList.Add(this.i);
            Assert.That(this.i.Equals(exampleList.GetElement(0)));

            exampleList.Add(this.d);
            Assert.That(this.d.Equals(exampleList.GetElement(1)));

            exampleList.Add(this.p);
            Assert.That(this.p.Equals(exampleList.GetElement(2)));

            exampleList.Add(this.s);
            Assert.That(this.s.Equals(exampleList.GetElement(3)));
        }
    }
}