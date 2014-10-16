using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_6;

namespace UnitTestProject_Lab_6
{
    [TestClass]
    public class From8to12_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            var number = 32;
            var expected = 26;
            var actual = OctTo12.OctToInt(number);
            Assert.AreEqual(expected, actual);
            
        }
    }
}
