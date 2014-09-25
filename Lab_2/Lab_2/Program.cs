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
            //var list = new List<Queue>();
            //for (int i = 0; i < 10; i++)
            //{
            //    var ar = new Queue();
            //    InitQueue(ar);
            //    list.Add(ar);
            //}
            //list.Sort();

            var ar = new Queue();
            InitQueue(ar);
            foreach (var item in ar)
                Console.WriteLine(item);

            //Console.WriteLine("This is a clone version");

            //ar.Clone();
            //foreach (var item in ar)
            //    Console.WriteLine(item);

            //var elem = ar.RemoveForward();
        }
        public static void InitQueue(IQueue qu)
        {
            for (int i = 0; i < 40000; i++)
            {
                qu.AddToTheEnd((double)r.Next(50) / r.Next(10));
            }

        }

    }
}
