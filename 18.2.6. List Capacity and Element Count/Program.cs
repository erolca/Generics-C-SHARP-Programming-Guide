using System;
using System.Collections.Generic;

class MainClass
{
    public static void Main()
    {
        List<char> lst = new List<char>();

        Console.WriteLine("Initial number of elements: " +
                           lst.Count);

        Console.WriteLine();

        Console.WriteLine("Adding 6 elements");

        lst.Add('C');
        lst.Add('A');
        lst.Add('E');
        lst.Add('B');
        lst.Add('D');
        lst.Add('F');

        Console.WriteLine("Number of elements: " +
                           lst.Count);

        Console.WriteLine("Adding 20 more elements");
        // Add enough elements to force lst to grow.  
        for (int i = 0; i < 20; i++)
            lst.Add((char)('a' + i));
        Console.WriteLine("Current capacity: " +
                           lst.Capacity);
        Console.WriteLine("Number of elements after adding 20: " +
                           lst.Count);
        Console.Write("Contents: ");
        foreach (char c in lst)
            Console.Write(c + " ");
        Console.WriteLine("\n");
    }
}
//Initial number of elements: 0

//Adding 6 elements
//Number of elements: 6
//Adding 20 more elements
//Current capacity: 32
//Number of elements after adding 20: 26
//Contents: C A E B D F a b c d e f g h i j k l m n o p q r s t