using System;
using System.Collections.Generic;
using System.Text;

public delegate void MyGenericDelegate<T>(T arg);
public delegate void MyDelegate(object arg);
class Program
{
    static void Main(string[] args)
    {
        MyDelegate d = new MyDelegate(MyTarget);
        d("string");
        MyDelegate d2 = new MyDelegate(MyTarget);
        d2(1);

        MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
        strTarget("str");
        MyGenericDelegate<int> intTarget = IntTarget;
        intTarget(9);
    }
    static void MyTarget(object arg)
    {
        if (arg is int)
        {
            int i = (int)arg;
            Console.WriteLine("++arg is: {0}", ++i);
        }

        if (arg is string)
        {
            string s = (string)arg;
            Console.WriteLine("arg in uppercase is: {0}", s.ToUpper());
        }
    }

    static void StringTarget(string arg)
    {
        Console.WriteLine("arg in uppercase is: {0}", arg.ToUpper());
    }

    static void IntTarget(int arg)
    {
        Console.WriteLine("++arg is: {0}", ++arg);
    }
}