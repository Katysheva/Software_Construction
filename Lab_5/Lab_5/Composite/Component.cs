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
        public abstract void Show(Graphics g, int level, int index);
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract Component GetChild(int index);

        public virtual void DrawElement(Graphics g, int level, int index)
        {
            var pen = new Pen(Color.DarkMagenta, 2);
            var brush = Brushes.Black;
            Font font = SystemFonts.MessageBoxFont;
            var dy = 35;
            var dx = 35;
            var location = new Point(dx * index, level * dy);
            var size = new Size(30, 30);
            var rect = new Rectangle(location, size);
            g.DrawEllipse(pen, rect);
            g.DrawString((level + 1).ToString() + (index + 1).ToString(), font, brush, rect.X + rect.Width / 4, rect.Y + rect.Height / 4);
        }
    }
}
