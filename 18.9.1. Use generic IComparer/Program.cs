using System;
using System.Collections.Generic;

// Create an IComparer<T> for Product objects. 
// T Product temsil edebilir..
class ProductComparer<T> : IComparer<T> where T : Product
{

    // Implement the IComparer<T> interface. 
    public int Compare(T obj1, T obj2)
    {
        return obj1.name.CompareTo(obj2.name);
    }

}





class Product
{
    public string name;
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
        return
          String.Format("{0,-10}Cost: {1,6:C}  On hand: {2}",
                        name, cost, onhand);
    }
}

class MyClass<T> where T : A
{
    T t;
    public void X()
    {

    }

}

class A
{ }

class B : A
{ }


class C : B
{ }



class MainClass
{
    public static void Main()
    {


        /*-1*/
        MyClass < A > ml= new MyClass<A>();

        /*-2*/
        ProductComparer<Product> comp = new ProductComparer<Product>();
        List<Product> inv = new List<Product>();

        // Add elements to the list 
        inv.Add(new Product("A", 5.5, 3));
        inv.Add(new Product("B", 8.9, 2));
        inv.Add(new Product("C", 3.0, 4));
        inv.Add(new Product("D", 1.8, 8));

        Console.WriteLine("Product list before sorting:");
        foreach (Product i in inv)
        {
            Console.WriteLine("   " + i);
        }
        Console.WriteLine();

        // Sort the list using an IComparer. 
        inv.Sort(comp);

        Console.WriteLine("Product list after sorting:");
        foreach (Product i in inv)
        {
            Console.WriteLine("   " + i);
        }
    }
}
//Product list before sorting:
//   A Cost:  $5.50  On hand: 3
//   B Cost:  $8.90  On hand: 2
//   C Cost:  $3.00  On hand: 4
//   D Cost:  $1.80  On hand: 8

//Product list after sorting:
//   A Cost:  $5.50  On hand: 3
//   B Cost:  $8.90  On hand: 2
//   C Cost:  $3.00  On hand: 4
//   D Cost:  $1.80  On hand: 8