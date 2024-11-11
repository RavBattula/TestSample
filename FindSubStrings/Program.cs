using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSubStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fullString = "Hello this is Ravi, I am practing some samples";
            string sub1 = "Ravi1";
            if (fullString.Contains(sub1))
            {
                int index = fullString.IndexOf(sub1);
                Console.WriteLine($"Sub string {sub1} found and index is {index}");
            }
            else
            {
                Console.WriteLine($"Sub string {sub1} not found");
            }
            Console.Read();
        }
    }
}
