using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureElapsedTime
{
    internal class DoSomething
    {
        public void DoSomeLongOp()
        {
            DoActualImplimentation();
        }

        private void DoActualImplimentation()
        {
            Task.Delay(1000).Wait();
            Console.WriteLine("This method operation completed");
        }
    }
}
