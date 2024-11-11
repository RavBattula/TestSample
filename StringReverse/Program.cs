using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            
            var temp = s.ToCharArray();
            string final = string.Empty;
            for(int l = temp.Length - 1; l >= 0; l--)
            {
                //final = final + temp[l];
                final = string.Concat(final, temp[l]);
            }

            Console.WriteLine(s);
            Console.WriteLine(final);
            Console.Read();
        }
    }
}
