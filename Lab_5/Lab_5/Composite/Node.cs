using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Node : Component
    {
        List<Component> childList;
        string color;
        string shape;

        public Node()
        {
            childList = new List<Component>();
        }

        public override void Show()
        {
            foreach (var item in childList)
                item.Show();
        }

        public override void Add(Component component)
        {
            childList.Add(component);
        }

        public override void Remove(Component component)
        {
            childList.Remove(component);
        }

        public override Component GetChild(int index)
        {
            return childList[index];
        }

        public override Component Color(string color)
        {
            this.color = color;
            return this;
        }
        public override Component Shape(string shape)
        {
            this.shape = shape;
            return this;
        }
    }
}
