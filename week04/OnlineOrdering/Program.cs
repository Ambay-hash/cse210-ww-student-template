using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
    }
}

using System;
using System.Collections.Generic;

// Product class
public class Product
{   private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string ProductId
    {
        get { return _productId; }
        set { _productId = value; }
    }

    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }

    public decimal TotalCost
    {
        get { return _price * _quantity; }
    }
}

public class Address
{   private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public string StreetAddress
    {
        get { return _streetAddress; }
        set { _streetAddress = value; }
    }

    public string City
    {
        get { return _city; }
        set { _city = value; }
    }
public string StateProvince
    {
        get { return _stateProvince; }
        set { _stateProvince = value; }
    }

    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }

    public bool IsInUSA
    {
        get { return _country.ToUpper() == "USA"; }
    }

    public string FullAddress
    {
        get
        {
            return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
        }
    }
}

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Address Address
    {
        get { return _address; }
        set { _address = value; }
    }

    public bool IsInUSA
    {
        get { return _address.IsInUSA; }
    }

    public string FullAddress
    {
        get { return _address.FullAddress; }
    }
}

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private decimal _shippingCostUSA = 5;
    private decimal _shippingCostInternational = 35;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public string PackingLabel
    {
        get
        {
            string label = "";
            foreach (Product product in _products)
            {
                label += $"{product.Name} ({product.ProductId})\n";
            }
            return label;
        }
    }
public string ShippingLabel
    {
        get
        {
            return _customer.FullAddress;
        }
    }
 public decimal TotalPrice
    {
        get
        {
            decimal total = 0;
            foreach (Product product in _products)
            {
                total += product.TotalCost;
            }

            if (_customer.IsInUSA)
            {
                total += _shippingCostUSA;
            }
            else
            {
                total += _shippingCostInternational;
            }

            return total;
        }
    }
}
class Program
{
    static void Main()
    {
        Address address1 = new Address("123 First street", "Town", "CA", "USA");
        Address address2 = new Address("456 Yonge street", "Othertown", "ON", "Canada");
        Address address3 = new Address("456 ", "Avenues", "ON", "Mexico");


        Customer customer1 = new Customer("Ambayo Roney", address1);
        Customer customer2 = new Customer("Kaudha Josephine", address2);
        Customer customer3 = new Customer("Aketch Anne", address3);

        Product product1 = new Product("Saw", "D404", 12.99m, 2);
        Product product2 = new Product("Thingy", "TQ10", 5.29m, 3);
        Product product3 = new Product("wedge", "GY03", 10.91m, 2);
        Product product4 = new Product("Generator", "FS19", 5.9m, 1);
        Product product5 = new Product("hummer", "WZ210", 12.99m, 3);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Order order3 = new Order(customer3);
        order3.AddProduct(product3);
        order3.AddProduct(product1);
        order3.AddProduct(product4);

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.PackingLabel);
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.ShippingLabel);
        Console.WriteLine("Total Price: $" + order1.TotalPrice);


        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.PackingLabel);
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.ShippingLabel);
        Console.WriteLine("Total Price: $" + order2.TotalPrice);
        Console.WriteLine();

        Console.WriteLine("Order 3:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order3.PackingLabel);
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order3.ShippingLabel);
        Console.WriteLine("Total Price: $" + order3.TotalPrice);
    }
}