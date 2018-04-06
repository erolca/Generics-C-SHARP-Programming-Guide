using System;
using System.Collections.Generic;

class Product
{
    string name;
    double cost;
    int onhand;

    public Product(string n, double c, int h)
    {
        name = n;
        cost = c;
        onhand = h;
    }

    public override string ToString()
    {
        return   String.Format("{0,-10}Cost: {1,6:C}  On hand: {2}",
                        name, cost, onhand);
    }
}

class MainClass
{
    public static void Main()
    {
        List<Product> inv = new List<Product>();

        // Add elements to the list 
        inv.Add(new Product("A", 5.9, 3));
        inv.Add(new Product("B", 8.2, 2));
        inv.Add(new Product("C", 3.5, 4));
        inv.Add(new Product("D", 1.8, 8));

        Console.WriteLine("Product list:");
        foreach (Product i in inv)
        {
            Console.WriteLine("   " + i);
        }
    }
}
//Product list:
//   A Cost:  $5.90  On hand: 3
//   B Cost:  $8.20  On hand: 2
//   C Cost:  $3.50  On hand: 4
//   D Cost:  $1.80  On hand: 8