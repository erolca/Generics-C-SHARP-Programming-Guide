using System;


//18.16.3.	A nongeneric class can be the base class of a generic derived class

class NonGen
{
    int num;

    public NonGen(int i)
    {
        num = i;
    }

    public int getnum()
    {
        return num;
    }
}

class Gen<T> : NonGen
{
    T ob;

    public Gen(T o, int i) : base(i)
    {
        ob = o;
    }

    public T getob()
    {
        return ob;
    }
}

class MainClass
{
    public static void Main()
    {
        Gen<String> w = new Gen<String>("Hello", 4);

        Console.Write(w.getob() + " ");
        Console.WriteLine(w.getnum());
    }
}
//Hello 4