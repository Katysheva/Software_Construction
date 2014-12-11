using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Observer
{
    class Car
    {
        Dictionary<Color, string> map = new Dictionary<Color, string>()
        {
            {Color.Red, "Stay"},
            {Color.Yellow, "Ready"},
            {Color.Green, "Go"}
        };
        public string State { get; set; }
        public Car()
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
