using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cust_Collection;
namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            Operation o = new Operation();
            o.Add(4);
            o.Add(8);
            o.Add(8);
            o.Add(0);
            o.Add(5);
            o.Add(8);
            o.Add(6);
            o.Add(6);
            o.Add(6);
            o.Add(6);
            
            // o.Truncate();
            //o.Delete(8);
            // o.Delete(6);
            o.Sort();
            // o.Display();
            Console.WriteLine(o.Contain(5));
            foreach ( object i in o)
            {
                Console.WriteLine(i);
            }
            Console.Read();          
        }
    }
}
