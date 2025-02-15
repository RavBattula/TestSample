internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public virtual bool Validate()
    {
        return true;
    }

    public abstract bool StrictValidate();
}

public class Manager: Employee
{
    public override bool StrictValidate()
    {
        throw new NotImplementedException();
    }

    public override bool Validate()
    {
        return base.Validate();
    }
}
