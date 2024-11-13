internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int[] myArr = { 1, 2, 3 };
        foreach (int i in myArr)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Changing the size of the array");
        Array.Resize<int>(ref myArr, 10);
        foreach (int i in myArr)
        {
            Console.WriteLine(i);
        }

        Console.Read();
    }
}