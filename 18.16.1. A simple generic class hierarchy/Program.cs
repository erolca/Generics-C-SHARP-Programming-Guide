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

class Gen2<T> : Gen<T>
{
    public Gen2(T o) : base(o)
    {
    }
}

class MainClass
{
    public static void Main()
    {
        Gen2<string> g2 = new Gen2<string>("Hello");

        Console.WriteLine(g2.getob());
    }
}
//Hello