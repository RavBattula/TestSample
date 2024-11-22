internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Person person = new Person("Ravi", "Battula", 1);
        Console.WriteLine($"Name: {person.FirstName}, LastName: {person.LastName}, Id: {person.Id}");
    }
}

public record Person(string FirstName, string LastName, int Id) 
    //FirstName, LastName ... these properties acts as readonly properties, can init, but can not set later. 
{
}