using System;


// T is a type parameter that will be replaced by a real type when an object of type Gen is created.

class Gen<T>
{
    T ob;

    public Gen(T o)
    {
        ob = o;
    }

    public T getob()
    {
        return ob;
    }

    public void showType()
    {
        Console.WriteLine("Type of T is " + typeof(T));
    }
}

class MainClass
{
    public static void Main()
    {
        Gen<int> iOb = new Gen<int>(102);
        iOb.showType();

        int v = iOb.getob();
        Console.WriteLine("value: " + v);

        Console.WriteLine();

        Gen<string> strOb = new Gen<string>("Generics add power.");
        strOb.showType();
        string str = strOb.getob();
        Console.WriteLine("value: " + str);
    }
}