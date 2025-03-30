using System;

class Program
{
    static void Main()
    {
        // Create Addresses
        var addr1 = new Address("123 Samora Machel Ave", "Harare", "Harare Province", "Zimbabwe");
        var addr2 = new Address("45 Joshua Nkomo St", "Bulawayo", "Bulawayo Province", "Zimbabwe");

        // Create Customers
        var cust1 = new Customer("Tafadzwa Moyo", addr1);
        var cust2 = new Customer("Chipo Ndlovu", addr2);

        // Create Products
        var prod1 = new Product("Laptop", "L123", 1200.00, 1);
        var prod2 = new Product("Mouse", "M456", 25.00, 2);
        var prod3 = new Product("Keyboard", "K789", 75.00, 1);
        var prod4 = new Product("Monitor", "D222", 300.00, 1);

        // Create Orders
        var order1 = new Order(cust1);
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);

        var order2 = new Order(cust2);
        order2.AddProduct(prod3);
        order2.AddProduct(prod4);

        // Display Order Details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");
        Console.WriteLine("-------------------------\n");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}
