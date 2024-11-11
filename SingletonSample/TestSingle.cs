using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonSample
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

        public void DoSomeThing(int i)
        {
            Console.WriteLine($"Do some thing {i}");
        }
    }
}
