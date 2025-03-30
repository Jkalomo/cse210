using System.Collections.Generic;

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product) => _products.Add(product);

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
        var label = "Packing List:\n";
        foreach (var product in _products)
        {
            label += $"- {product.GetProductInfo()}\n";
        }
        return label.TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"Shipping To:\n{_customer.GetName()}\n{_customer.GetShippingAddress()}";
    }
}
