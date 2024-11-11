using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                Thread thread = new Thread(() =>
                {
                    TestSingle.TestSingleObject.DoSomeThing(i);
                });

                thread.Start();
            }

            Console.Read();
        }
    }
}
