using System;

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
}

class Gen2<T, V> : Gen<T>
{
    V ob2;

    public Gen2(T o, V o2) : base(o)
    {
        ob2 = o2;
    }

    public V getob2()
    {
        return ob2;
    }
}

class MainClass
{
    public static void Main()
    {

        Gen2<string, int> x = new Gen2<string, int>("Value is: ", 99);

        Console.Write(x.getob());
        Console.WriteLine(x.getob2());
    }
}
//Value is: 99