using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Observer
{
    delegate void InnerDelegate(Color color);

    class TrafficLights
    {
        private Color color;

        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                OnColorChanged(color);
            }
        }

        public event InnerDelegate ColorChanged;

        private void OnColorChanged(Color color)
        {
            if (ColorChanged != null)
            {
                ColorChanged(color);
            }
        }
    }
}
