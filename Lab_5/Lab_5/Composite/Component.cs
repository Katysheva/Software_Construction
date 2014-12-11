using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    abstract class Component
    {
        /// <summary>
        /// Show each children. Return count of shown children.
        /// </summary>
        public abstract int Show(Graphics g, int depth, int shift);
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public int LocalIndex { get; set; }

        protected void DrawSelf(Graphics g, int depth, int shift)
        {
            var pen = new Pen(Color.DarkMagenta, 2);
            var brush = Brushes.Black;
            Font font = SystemFonts.MessageBoxFont;
            var size = new Size(30, 30);
            var gapWidth = 5;
            var dx = size.Width + gapWidth;
            var location = new Point(dx * depth, dx * shift);
            var rect = new Rectangle(location, size);
            g.DrawEllipse(pen, rect);
            g.DrawString(
                (depth + 1).ToString() + (LocalIndex + 1).ToString(), 
                font, brush,
                new PointF(rect.Location.X + rect.Size.Width / 4, rect.Location.Y + rect.Size.Height / 4));

        }
        public abstract Component GetChild(int index);
  }
}
