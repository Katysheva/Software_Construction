using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Leaf : Component
    {
        public override void Show()
        {
            //throw new NotImplementedException();
        }

        public override void Add(Component component)
        {
            throw new NotSupportedException();
        }

        public override void Remove(Component component)
        {
            throw new NotSupportedException();
        }

        public override Component GetChild(int index)
        {
            throw new NotSupportedException();
        }
    }
}
