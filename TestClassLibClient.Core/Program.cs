internal class Program
{
    private static void Main(string[] args)
    {
        TestClassLibSample.TestClass testClass = new TestClassLibSample.TestClass();
        testClass.FirstName = "Ravi";
        Console.WriteLine($"Hello {testClass.FirstName}");
    }
}