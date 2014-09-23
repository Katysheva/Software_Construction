using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Queue : IQueue, IEnumerable, IComparable, ICloneable
    {
        private double[] array;
        private int pointerEnd;
        private int pointerForward;
        public int Length
        {
            get { return pointerEnd - pointerForward; }
        }

        public Queue()
        {
            array = new double[1];
            pointerEnd = 0;
            pointerForward = 0;
        }

        public void AddToTheEnd(double element)
        {
            if (pointerEnd == array.Length)
                ExtendArray(1);
            array[pointerEnd] = element;
            pointerEnd++;
        }

        void ExtendArray(int count)
        {
            var tmpArray = new double[array.Length + count];
            array.CopyTo(tmpArray, 0);
            array = tmpArray;
        }

        public double RemoveForward()
        {
            if (pointerEnd == pointerForward)
                throw new InvalidOperationException("Queue is empty");
            var element = array[pointerForward];
            pointerForward++;
            return element;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; ++i)
                yield return array[i];
        }

        public int CompareTo(object obj)
        {
            var que = obj as Queue;
            return this.Length.CompareTo(que.Length);
        }

        public Queue ShallowClone()
        {
            return (Queue)this.MemberwiseClone();
        }

        public object Clone()
        {
            return new Queue();
        }
    }
}
