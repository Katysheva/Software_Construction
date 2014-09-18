using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            var ar = new Queue();
            InitQueue(ar);
            var elem = ar.RemoveForward();
        }
        public static void InitQueue(IQueue qu)
        {
            for (int i = 0; i < 50; i++)
                qu.AddToTheEnd((double)r.Next(50) / r.Next(10));
        }

    }
}
