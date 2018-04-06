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

        // Use foreach loop to display the list.  
        Console.Write("Contents: ");
        foreach (char c in lst)
            Console.Write(c + " ");
        Console.WriteLine("\n");
    }
}
//Initial number of elements: 0

//Adding 6 elements
//Number of elements: 6
//Contents: C A E B D F