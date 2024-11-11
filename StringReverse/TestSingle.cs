using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReverse
{
    internal class TestSingle
    {
        private static TestSingle testSingleObject = new TestSingle();
        private TestSingle()
        {
            Console.WriteLine("Constructor called");
        }

        public static TestSingle TestSingleObject
        {
            get
            {
                return testSingleObject;
            }
        }
    }
}
