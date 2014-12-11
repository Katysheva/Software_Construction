using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Leaf : Component
    {

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

        public override int Show(Graphics g, int depth, int shift)
        {
            DrawSelf(g, depth, shift);
            return 0;
        }
    }
}
