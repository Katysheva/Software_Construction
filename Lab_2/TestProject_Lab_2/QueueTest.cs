using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var q = new Queue<double>();
            var count = (r.Next(100) + 1) / (r.Next(15) + 1);
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
            var q = new Queue<double>();
            q.RemoveForward();
        }
        [TestMethod]
        public void DequeueIntTest()
        {
            var q = new Queue<int>();
            var count = r.Next(100) + 1;
            var firstAdded = 27;
            q.AddToTheEnd(firstAdded);
            for (int i = 0; i < count; i++)
                q.AddToTheEnd(r.Next(100));
            var actual = q.RemoveForward();
            Assert.AreEqual(firstAdded, actual);
        }
        [TestMethod]
        public void DequeueCharTest()
        {
            var q = new Queue<char>();
            var count = r.Next(100) + 1;
            var firstAdded = 'A';
            q.AddToTheEnd(firstAdded);
            for (int i = 0; i < count; i++)
                q.AddToTheEnd('f');
            var actual = q.RemoveForward();
            Assert.AreEqual(firstAdded, actual);
        }
        [TestMethod]
        public void DequeueStringTest()
        {
            var q = new Queue<string>();
            var count = r.Next(100) + 1;
            var firstAdded = "Hello!";
            q.AddToTheEnd(firstAdded);
            for (int i = 0; i < count; i++)
                q.AddToTheEnd("Hi!");
            var actual = q.RemoveForward();
            Assert.AreEqual(firstAdded, actual);
        }
        [TestMethod]
        public void DoubleEnumeratorTest()
        {
            var q = new Queue<double>();
            for (int i = 0; i < 4; i++)
                q.AddToTheEnd(1 + i + (i * 0.2));
            var expected = "12.23.44.6";
            var actual = "";
            foreach (var item in q)
                actual += item;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IntEnumeratorTest()
        {
            var q = new Queue<int>();
            for (int i = 0; i < 7; i++)
                q.AddToTheEnd(1 + i);
            var expected = "1234567";
            var actual = "";
            foreach (var item in q)
                actual += item;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ComparableTest()
        {
            var a = new Queue<int>();
            var b = new Queue<int>();
            var countA = r.Next(100) + 1;
            var countB = r.Next(100) + 1;
            var expected = 0;
            var actual = 0;
            for (int i = 0; i < countA; i++)
            {
                a.AddToTheEnd(r.Next(100));
            }
            for (int i = 0; i < countB; i++)
            {
                b.AddToTheEnd(r.Next(100));
            }
            if (a.Length > b.Length)
                expected = 1;
            if (a.Length < b.Length)
                expected = -1;
            actual = a.CompareTo(b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ClonableTest()
        {
            var a = new Queue<int>();
            var count = r.Next(50);
            var expected = 0;
            for (int i = 0; i < count; i++)
            {
                a.AddToTheEnd(r.Next(100));
            }
            var b = (Queue<int>)a.Clone();
            var actual = a.CompareTo(b);

            Assert.AreEqual(expected, actual);
        }
    }
}
