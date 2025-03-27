using System;
using System.Collections.Generic;

class Address
{
    private string _street;
    private string _city;
    private string _province;
    private string _country;

    public Address(string street, string city, string province, string country)
    {
        _street = street;
        _city = city;
        _province = province;
        _country = country;
    }

    public bool IsInZimbabwe()
    {
        return _country.ToLower() == "zimbabwe";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_province}\n{_country}";
    }
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInZimbabwe()
    {
        return _address.IsInZimbabwe();
    }

    public string GetName()
    {
        return _name;
    }

    public string GetShippingAddress()
    {
        return _address.GetFullAddress();
    }
}

class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetProductInfo()
    {
        return $"{_name} (ID: {_productId})";
    }
}

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }
        total += _customer.IsInZimbabwe() ? 5 : 35; // Shipping cost
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing List:\n";
        foreach (var product in _products)
        {
            label += "- " + product.GetProductInfo() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping To:\n{_customer.GetName()}\n{_customer.GetShippingAddress()}";
    }
}

class Program
{
    static void Main()
    {
        // Create Addresses in Zimbabwe
        Address addr1 = new Address("123 Samora Machel Ave", "Harare", "Harare Province", "Zimbabwe");
        Address addr2 = new Address("45 Joshua Nkomo St", "Bulawayo", "Bulawayo Province", "Zimbabwe");

        // Create Customers
        Customer cust1 = new Customer("Tafadzwa Moyo", addr1);
        Customer cust2 = new Customer("Chipo Ndlovu", addr2);

        // Create Products
        Product prod1 = new Product("Laptop", "L123", 1200.00, 1);
        Product prod2 = new Product("Mouse", "M456", 25.00, 2);
        Product prod3 = new Product("Keyboard", "K789", 75.00, 1);
        Product prod4 = new Product("Monitor", "D222", 300.00, 1);

        // Create Orders
        Order order1 = new Order(cust1);
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);

        Order order2 = new Order(cust2);
        order2.AddProduct(prod3);
        order2.AddProduct(prod4);

        // Display Order Details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order1.GetTotalCost());
        Console.WriteLine("\n-------------------------\n");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order2.GetTotalCost());
    }
}
