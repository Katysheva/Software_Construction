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

        public Node()
        {
            childList = new List<Component>();
        }

        public override void Show()
        {
            throw new NotImplementedException();
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
