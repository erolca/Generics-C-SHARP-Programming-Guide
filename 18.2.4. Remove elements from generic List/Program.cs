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

        Console.WriteLine("Removing 2 elements");
        // Remove elements from the array list.  
        lst.Remove('F');
        lst.Remove('A');

        Console.WriteLine("Number of elements: " +
                           lst.Count);
    }
}
//Initial number of elements: 0

//Adding 6 elements
//Number of elements: 6
//Removing 2 elements
//Number of elements: 4