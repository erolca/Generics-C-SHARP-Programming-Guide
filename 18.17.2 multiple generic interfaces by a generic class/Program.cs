using System;
using System.Collections.Generic;

interface GenericInterface<T>
{
    T getValue(T inValue);
}

class MyClass : GenericInterface<int>, GenericInterface<string>
{
    public int getValue(int inValue)
    {
        return inValue;
    }

    public string getValue(string inValue)
    {
        return inValue;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass TrivInt = new MyClass();
        MyClass TrivString = new MyClass();

        Console.WriteLine("{0}", TrivInt.getValue(5));
        Console.WriteLine("{0}", TrivString.getValue("Hi there."));
    }
}
//5
//Hi there