using System;
using System.ComponentModel;

class MainClass
{
    static void PrintType<T>(T first, T second)
    {
        Console.WriteLine(typeof(T));
    }

    static void Main()
    {
        PrintType(1, new object());
    }
}