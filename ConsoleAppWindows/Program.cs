using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClassLibSample;

namespace ConsoleAppWindows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestClass testClass = new TestClass();
            testClass.FirstName = "Ravi";
            testClass.LastName = "Battula";
            Console.WriteLine($"Hello {testClass.FirstName} {testClass.LastName}");
            Console.Read();
        }
    }
}
