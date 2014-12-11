using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Observer
{
    class FootPassenger
    {
        Dictionary<Color, string> map = new Dictionary<Color, string>()
        {
            {Color.Red, "Go"},
            {Color.Yellow, "Ready"},
            {Color.Green, "Stay"}
        };

        public string State { get; set; }

        public FootPassenger()
        {
            State = "Stay";
        }

        public void React(Color color)
        {
            if (map.ContainsKey(color))
                State = map[color];
        }

    }
}
