// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using MeasureElapsedTime;

//DateTime startTime = DateTime.UtcNow;
//Stopwatch sw = Stopwatch.StartNew(); // this is same as sw = new StopWatch() and sw.Start();
var startTime = Stopwatch.GetTimestamp(); // this gives timenow ticks.
DoSomething doSomething = new DoSomething();
doSomething.DoSomeLongOp();

//var delta = DateTime.UtcNow - startTime; // This is wrong. //Utc time is long opertion and will be some overhead.
//sw.Stop();
//var delta  = sw.Elapsed; // This is also not completely correct, there is some overhead here also.
var delta = Stopwatch.GetElapsedTime(startTime); // THis returns time span
Console.WriteLine($"The elapsed time is {delta}");

