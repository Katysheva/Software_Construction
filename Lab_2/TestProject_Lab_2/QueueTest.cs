using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Lab_2;

namespace TestProject_Lab_2
{
    [TestClass]
    public class QueueTest
    {
        Random r = new Random();

        [TestMethod]
        public void DequeueTest()
        {
            var q = new Queue();
            var count = r.Next(100) + 1;
            var firstAdded = r.Next();
            q.AddToTheEnd(firstAdded);
            for(int i = 0; i < count; i++)
                q.AddToTheEnd(r.Next());
            var actual = q.RemoveForward();
            Assert.AreEqual(firstAdded, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidDequeueTest()
        {
            var q = new Queue();
            q.RemoveForward();
        }

        [TestMethod]
        public void ExtendEnumeratorTest()
        {
            var q = new Queue();
            for (int i = 0; i < 20; i++)
                q.AddToTheEnd(1 + i);
            var expected = "1234567891011121314151617181920";
            var actual = "";
            foreach (var item in q)
                actual += item;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnumeratorTest()
        {
            var q = new Queue();
            for (int i = 0; i < 7; i++)
                q.AddToTheEnd(1 + i);
            var expected = "1234567";
            var actual = "";
            foreach (var item in q)
                actual += item;
            Assert.AreEqual(expected, actual);
        }
        //[TestMethod]
        //public void SortTest()
        //{
        //    var list = new List<Queue>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        var ar = new Queue();
        //        for (int j = 0; j < r.Next(100); i++)
        //            ar.AddToTheEnd((double)r.Next(50) / r.Next(10));
        //        list.Add(ar);
        //    }
        //    list.Sort();
        //}
    }
}
