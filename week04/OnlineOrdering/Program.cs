using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1: USA customer
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("Alice Smith", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LT123", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "MS456", 29.99m, 2));
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}\n");

        // Order 2: Non-USA customer
        Address address2 = new Address("456 Maple Rd", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Johnson", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "PH789", 699.99m, 1));
        order2.AddProduct(new Product("Charger", "CH012", 19.99m, 3));
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
    }
}