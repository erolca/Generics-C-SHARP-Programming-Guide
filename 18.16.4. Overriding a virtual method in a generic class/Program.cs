using System;

class Gen<T>
{
    protected T ob;

    public Gen(T o)
    {
        ob = o;
    }

    public virtual T getob()
    {
        Console.Write("Gen's getob(): ");
        return ob;
    }
}

class Gen2<T> : Gen<T>
{

    public Gen2(T o) : base(o) { }

    public override T getob()
    {
        Console.Write("Gen2's getob(): ");
        return ob;
    }
}

class MainClass
{
    public static void Main()
    {
        Gen<int> iOb = new Gen<int>(88);

        Console.WriteLine(iOb.getob());

        iOb = new Gen2<int>(99);

        Console.WriteLine(iOb.getob());
    }
}
//Gen's getob(): 88
//Gen2's getob(): 99