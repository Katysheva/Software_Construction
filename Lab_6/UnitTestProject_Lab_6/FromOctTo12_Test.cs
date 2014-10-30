using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_6;
using System.Collections.Generic;

namespace UnitTestProject_Lab_6
{
    [TestClass]
    public class FromOctTo12_Test
    {
        [TestMethod]
        public void OctToIntTest()
        {
            var number = "32";
            var expected = 26;
            var actual = OctTo12.OctToInt(number);
            Assert.AreEqual(expected, actual);
        }
    }
}
