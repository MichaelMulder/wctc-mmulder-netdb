using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassString
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Jimmy";
            string address = "123 Pine St";
            Console.WriteLine("|{0, 4}| lives on |{1, 40}| Okay?", name, address);

            var pi = Math.PI;

            Console.WriteLine($"{pi}");

        }
    }
}
