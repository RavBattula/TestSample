internal class Program
{
    private static void Main(string[] args)
    {
        SomeClass a = new SomeClass(10);
        SomeClass b = new SomeClass(20);
        SomeClass c = a+b;
        Console.WriteLine(c.ToString());
        Console.Read();
    }
}

public class SomeClass
{
    private int someValue;

    public SomeClass(int someValue)
    {
        this.someValue = someValue;
    }

    public static SomeClass operator + (SomeClass a, SomeClass b)
    {
        return new SomeClass( a.someValue + b.someValue);
    }

    public override string ToString()
    {
        return this.someValue.ToString();
    }
}