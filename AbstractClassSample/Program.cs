internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Customer customer = new GoldCustomer() { ID = 1, Name = "Ravi"};
        customer.Price = 100;
        decimal discountedAmoount = customer.CalculateDiscount();
        Console.WriteLine(discountedAmoount.ToString());
        Console.WriteLine(customer.GetCustomerDetails());

        customer = new SilverCustomer() { ID = 1, Name = "Ravi" };
        customer.Price = 100;
        discountedAmoount = customer.CalculateDiscount();
        Console.WriteLine(discountedAmoount.ToString());
    }
}

public abstract class Customer
{
    public required string Name { get; set; }

    public required int ID { get; set; }

    public string Address { get; set; }

    public string ProductName { get; set; }

    public decimal Price { get; set; }

    public abstract decimal CalculateDiscount();

    public string GetCustomerDetails()
    {
        return $"Customer Name: {Name}, Customer ID: {ID}";
    }
}

public class GoldCustomer : Customer
{
    public override decimal CalculateDiscount()
    {
        return Price * 10/100;
    }
}

public class SilverCustomer : Customer
{
    public override decimal CalculateDiscount()
    {
        return Price * 5/100;
    }
}