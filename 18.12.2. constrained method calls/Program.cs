using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class MainClass
{
    static string GetToString<T>(T input)
    {
        return input.ToString();
    }

    public static void Main()
    {
        Console.WriteLine(GetToString<int>(10));

        Console.WriteLine(GetToString<string>("Hello World"));

    }
}
//10