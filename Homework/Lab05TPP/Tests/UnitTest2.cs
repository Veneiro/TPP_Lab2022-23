using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;
using PTP_HW_5;

namespace Tests
{
    [TestClass]
    public class UnitTest2
    {
        Person[] people = Factory.CreatePeople();
        FunctionsCopy fc = new FunctionsCopy();

        [TestMethod]
        public void TestMap()
        {
            var res = fc.Map<Person, string>(people, p => p.Surname + ", " + p.Name);
            Assert.AreEqual("Smith, James", res.GetEnumerator());

        }
    }
}
