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
        //    var list = new List<Queue<int>>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        var ar = new Queue<int>();
        //        InitQueue(ar);
        //        list.Add(ar);
        //    }
        //    list.Sort();
            //InitQueue(ar);
            //foreach (var item in ar)
            //    Console.WriteLine(item);

            //Console.WriteLine("This is a clone version");

            //ar.Clone();
            //foreach (var item in ar)
            //    Console.WriteLine(item);

            //var elem = ar.RemoveForward();

            var ar1 = new Queue<int>();
            InitQueue(ar1);
            var ar2 = ar1.Clone();
        }
        public static void InitQueue(IQueue<int> qu)
        {
            for (int i = 0; i < r.Next(100); i++)
            {
                qu.AddToTheEnd(r.Next(50) / r.Next(10));
            }
        }
    }
}
