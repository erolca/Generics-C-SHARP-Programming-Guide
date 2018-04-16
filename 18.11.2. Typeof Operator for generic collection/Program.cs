using System;
using System.Collections.Generic;
using System.ComponentModel;

class MainClass
{
    static internal void DemonstrateTypeof<X>()
    {
        Console.WriteLine(typeof(X));
        Console.WriteLine(typeof(List<X>));
        Console.WriteLine(typeof(Dictionary<string, X>));
        Console.WriteLine(typeof(List<long>));
        Console.WriteLine(typeof(Dictionary<long, Guid>));
    }

    static void Main()
    {
        DemonstrateTypeof<int>();
    }
}