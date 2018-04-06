using System;
using System.Collections.Generic;

using System.Collections;
using System.ComponentModel;

public class Product
{
    string name;
    public string Name
    {
        get { return name; }
    }

    decimal price;
    public decimal Price
    {
        get { return price; }
    }

    public Product(string name, decimal price)
    {
        this.name = name;
        this.price = price;
    }

    public static List<Product> GetSampleProducts()
    {
        List<Product> list = new List<Product>();
        list.Add(new Product("C", 9.99m));
        list.Add(new Product("A", 1.99m));
        list.Add(new Product("F", 2.99m));
        list.Add(new Product("S", 3.99m));
        return list;
    }

    public override string ToString()
    {
        return string.Format("{0}: {1}", name, price);
    }
}



class ListSortWithComparer
{
    class ProductNameComparer : IComparer<Product>
    {
        public int Compare(Product first, Product second)
        {
            return first.Name.CompareTo(second.Name);
        }
    }

    static void Main()
    {
        List<Product> products = Product.GetSampleProducts();
        products.Sort(new ProductNameComparer());
        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }
    }
}