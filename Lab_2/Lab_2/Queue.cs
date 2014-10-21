using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Queue<T> : IQueue<T>, IEnumerable, IComparable, ICloneable
    {
        private T[] array;
        private int pointerEnd;
        private int pointerForward;
        /// <summary>
        /// Получает размер массива
        /// </summary>
        public int Length
        {
            get { return pointerEnd - pointerForward; }
        }

        public Queue()
        {
            array = new T[1];
            pointerEnd = 0;
            pointerForward = 0;
        }
        /// <summary>
        /// Добавление элемента в конец очереди
        /// </summary>
        /// <param name="element"></param>
        public void AddToTheEnd(T element)
        {
            if (pointerEnd == array.Length)
                ExtendArray(1);
            array[pointerEnd] = element;
            pointerEnd++;
        }
        /// <summary>
        /// Расширение массива на заданное количество мест
        /// </summary>
        /// <param name="count"></param>
        void ExtendArray(int count)
        {
            var tmpArray = new T[array.Length + count];
            array.CopyTo(tmpArray, pointerForward);
            array = tmpArray;
        }
        /// <summary>
        /// Удаляет элемент из начала очереди и возвращает его
        /// </summary>
        /// <returns></returns>
        public T RemoveForward()
        {
            if (pointerEnd == pointerForward)
                throw new InvalidOperationException("Queue is empty");
            var element = array[pointerForward];
            pointerForward++;
            return element;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
                yield return array[i];
        }
        public int CompareTo(object obj)
        {
            var que = obj as Queue<T>;
            return this.Length.CompareTo(que.Length);
        }
        public Queue<T> ShallowClone()
        {
            return (Queue<T>)this.MemberwiseClone();
        }
        public object Clone()
        {
            var cloneQueue = new Queue<T>();
            foreach (var item in array)
            {
                cloneQueue.AddToTheEnd(item);
            }
            return cloneQueue;
        }
    }
}
