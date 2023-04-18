using Lab09;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Obtain the data multiple times and save it into different vectors
            BitcoinValueData[] vector = Utils.GetBitcoinData();
            BitcoinValueData[] vector2 = Utils.GetBitcoinData();
            BitcoinValueData[] vector3 = Utils.GetBitcoinData();
            BitcoinValueData[] vector4 = Utils.GetBitcoinData();

            // Assign the number of threads and the value to a variable
            int numberOfThreads = 50;
            int value = 7000;

            // Create the master thread for each vector
            Master master = new Master(vector, 1, value);
            Master master2 = new Master(vector2, 1, value);
            Master master3 = new Master(vector3, numberOfThreads, value);
            Master master4 = new Master(vector4, numberOfThreads, value);

            // Compute the Modulus for each master thread
            double result = master.ComputeModulus();
            double result2 = master2.ComputeModulus();
            double result3 = master3.ComputeModulus();
            double result4 = master4.ComputeModulus();

            // Check if the results are correct
            Assert.AreEqual(result, 2854);
            Assert.AreEqual(result2, 2854);
            Assert.AreEqual(result3, 2854);
            Assert.AreEqual(result4, 2854);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int value = 5;
            int numberOfThreads = 10;
            BitcoinValueData[] vector = new BitcoinValueData[10];
            for (int i = 0; i < vector.Length; i++)
            {
                BitcoinValueData b = new BitcoinValueData();
                b.Value = i + 1;
                vector[i] = b;
            }
            Master master = new Master(vector, 1, value);
            double result = master.ComputeModulus();
            Assert.AreEqual(6, result);

            master = new Master(vector, numberOfThreads, value);
            result = master.ComputeModulus();
            Assert.AreEqual(6, result);
        }
    }
}
