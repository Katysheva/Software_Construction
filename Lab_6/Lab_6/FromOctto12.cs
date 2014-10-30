using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class OctTo12
    {
        public static object OctToInt(string numbers)
        {
            var result = 0;
            var n = 1;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                int currNumber = int.Parse(numbers[i].ToString());
                result += currNumber * n;
                n *= 8;
            }
            return result;
        }

    }
}
