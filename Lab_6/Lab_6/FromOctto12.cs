using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class OctTo12
    {
        public static int OctToInt(string numbers)
        {
            int result = 0;
            var n = 1;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                int currNumber = int.Parse(numbers[i].ToString());
                result += currNumber * n;
                n *= 8;
            }
            return result;
        }

        public static object IntTo12(int number)
        {
            var result = new List<int>();
            while (number > 12)
            {
                result.Add(number % 12);
                number = number / 12;
            }
            result.Add(number);
            return Reverse(result); 
        }

        public static int Reverse(List<int> number)
        {
            int[] s = new int[number.Count];
            for (int i = number.Count - 1; i >= 0; i--)
            {
                s[number.Count - 1 - i] = number[i];
            }
            return int.Parse(string.Join<int>("", s));
        }
    }
}
