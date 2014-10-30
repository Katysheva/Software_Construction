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
        [TestMethod]
        public void IntTo12()
        {
            var number = 32;
            var expected = 28;
            var actual = OctTo12.IntTo12(number);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void OctTo12Test()
        {
            var number = "12375";
            var expected = 3139;
            var actual = OctTo12.IntTo12(OctTo12.OctToInt(number));
            Assert.AreEqual(expected, actual);
        }
    }
}
