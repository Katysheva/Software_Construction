using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    interface IQueue<T>
    {
        void AddToTheEnd(T element);
        T RemoveForward();
    }
}