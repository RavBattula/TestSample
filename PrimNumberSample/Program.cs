using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimNumberSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine(num);
                if (num < 0)
                {
                    Console.WriteLine("Number should be greater than 0");
                    Console.Read();
                    return;
                }

                int counter = 0;
                for (int i = 1; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        counter++;
                    }

                    if (counter >= 2)
                    {
                        break;
                    }
                }

                if (counter < 2 && num != 1)
                {
                    Console.WriteLine($"This number: {num} is prime");
                }
                else
                {
                    Console.WriteLine($"This number: {num} is not prime");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.Read();
        }
    }
}
