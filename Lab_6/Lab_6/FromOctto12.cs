using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class OctTo12
    {
        public static Dictionary<int, string> alphabet = new Dictionary<int, string>()
        {
            {0, "0"},
            {1, "1"},
            {2, "2"},
            {3, "3"},
            {4, "4"},
            {5, "5"},
            {6, "6"},
            {7, "7"},
            {8, "8"},
            {9, "9"},
            {10, "A"},
            {11, "B"}
        };
        public static int OctToInt(string numbers)
        {
            if (numbers == "")
                throw new ArgumentException("String is empty.");
            else
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
        }

        public static string IntTo12(int number)
        {
            var result = "";
            while (number > 0)
            {
                result = alphabet[number % 12] + result;
                number = number / 12;
            }
            return result; 
        }

    }
}
