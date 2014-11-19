using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace Lab_5
{
    class Node : Component
    {
        List<Component> childList;

        public Node()
        {
            childList = new List<Component>();
        }

        public override void Show(Graphics g, int level, int index)
        {
            DrawElement(g, level, index);
            int i = 0;
            foreach (var item in childList)
            {
                item.Show(g, level + 1, i);
                i++;
            }
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
    }
}
