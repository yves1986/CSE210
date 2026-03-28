using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ONLINE ORDERING SYSTEM\n");
        Console.WriteLine("=====================\n");

        // Create first order
        Console.WriteLine("ORDER #1");
        Console.WriteLine("--------");

        // Create address for customer 1 (USA)
        Address address1 = new Address("123 Main Street", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        
        // Create order and add products
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LAP123", 999.99, 1));
        order1.AddProduct(new Product("Wireless Mouse", "MOU456", 29.99, 2));
        order1.AddProduct(new Product("Laptop Bag", "BAG789", 49.99, 1));

        // Display order details
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine($"TOTAL COST: ${order1.GetTotalCost():F2}");
        
        Console.WriteLine("\n" + new string('=', 50) + "\n");

        // Create second order
        Console.WriteLine("ORDER #2");
        Console.WriteLine("--------");

        // Create address for customer 2 (Canada)
        Address address2 = new Address("456 Queen Street", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Maria Garcia", address2);
        
        // Create order and add products
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", "PHO111", 699.99, 1));
        order2.AddProduct(new Product("Phone Case", "CAS222", 19.99, 3));
        order2.AddProduct(new Product("Screen Protector", "SCR333", 9.99, 2));
        order2.AddProduct(new Product("Wireless Charger", "CHG444", 39.99, 1));

        // Display order details
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine($"TOTAL COST: ${order2.GetTotalCost():F2}");

        Console.WriteLine("\n" + new string('=', 50) + "\n");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}