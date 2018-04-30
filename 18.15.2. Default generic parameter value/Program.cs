using System;

public class Bag<T>
{
    public Bag()
    {
        // Create initial capacity.
        imp = new T[4];
        for (int i = 0; i < imp.Length; ++i)
        {
            imp[i] = default(T);
        }
    }

    public bool IsNull(int i)
    {
        if (i < 0 || i >= imp.Length)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (Object.Equals(imp[i], default(T)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private T[] imp;
}

public class MainClass
{
    static void Main()
    {
        Bag<int> intBag = new Bag<int>();

        Bag<object> objBag = new Bag<object>();

        Console.WriteLine(intBag.IsNull(0));
        Console.WriteLine(objBag.IsNull(0));
    }
}
//True
//True