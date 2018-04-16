using System;
using System.Collections.Generic;


//18.11.1.	Create generic Bag collection class based on generic List

public class Bag<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public T Remove()
    {
        T item = default(T);

        if (items.Count != 0)
        {
            item = items[0];
            items.RemoveAt(0);
        }
        return item;
    }

    public T[] RemoveAll()
    {
        T[] i = items.ToArray();
        items.Clear();
        return i;
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        Bag<string> bag = new Bag<string>();

        bag.Add("D");
        bag.Add("B");
        bag.Add("G");
        bag.Add("M");
        bag.Add("N");
        bag.Add("I");

        Console.WriteLine("Item 1 = {0}", bag.Remove());
        Console.WriteLine("Item 2 = {0}", bag.Remove());
        Console.WriteLine("Item 3 = {0}", bag.Remove());
        Console.WriteLine("Item 4 = {0}", bag.Remove());

        string[] s = bag.RemoveAll();
    }
}
//Item 1 = D
//Item 2 = B
//Item 3 = G
//Item 4 = M