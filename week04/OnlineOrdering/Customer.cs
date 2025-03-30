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

    public string GetName() => _name;
    public string GetShippingAddress() => _address.GetFullAddress();
}
