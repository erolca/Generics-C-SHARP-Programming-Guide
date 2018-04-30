using System;
using System.Collections.Generic;

interface GenericInterface<T>
{
    T getValue(T tValue);
}

class MyClass<T> : GenericInterface<T>
{
    public T getValue(T tValue)
    {
        return tValue;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass<int> intObject = new MyClass<int>();
        MyClass<string> stringObject = new MyClass<string>();

        Console.WriteLine("{0}", intObject.getValue(5));
        Console.WriteLine("{0}", stringObject.getValue("Hi there."));
    }
}
//5
//Hi there.