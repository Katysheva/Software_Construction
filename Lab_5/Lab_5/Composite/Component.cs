using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    abstract class Component
    {

        public abstract void Show();
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract Component GetChild(int index);

        public abstract Component Color(string color);
        public abstract Component Shape(string shape);

    }
}
