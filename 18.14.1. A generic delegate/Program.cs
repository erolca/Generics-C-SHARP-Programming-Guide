using System;

delegate T SomeOp<T>(T v);

class MainClass
{
    static int sum(int v)
    {
        return v;
    }

    static string reflect(string str)
    {
        return str;
    }

    public static void Main()
    {
        SomeOp<int> intDel = sum;
        Console.WriteLine(intDel(3));

        SomeOp<string> strDel = reflect;
        Console.WriteLine(strDel("Hello"));
    }
}
//3
//Hello