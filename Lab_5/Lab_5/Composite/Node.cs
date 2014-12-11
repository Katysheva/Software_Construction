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

       

        public override void Add(Component component)
        {
            childList.Add(component);
            component.LocalIndex = childList.IndexOf(component);
        }

        public override void Remove(Component component)
        {
            childList.Remove(component);
        }

        public override Component GetChild(int index)
        {
            return childList[index];
        }


        public override int Show(Graphics g, int depth, int shift)
        {
            DrawSelf(g, depth, shift);
            int i = 0;
            int currentChildrensCount = 0;
            int totalChildrensCount = 0;
            foreach (var child in childList)
            {
                i++;
                currentChildrensCount = child.Show(g, depth + 1, shift + i + currentChildrensCount);
                totalChildrensCount += currentChildrensCount;
            }
            return totalChildrensCount + i;
        }

    }
}
