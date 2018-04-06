using System;
using System.Collections.Generic;


//18.2.3.	Add value to Generic List and display the array list using array indexing

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

        Console.Write("Current contents: ");
        for (int i = 0; i < lst.Count; i++)
            Console.Write(lst[i] + " ");
        Console.WriteLine("\n");
    }
} 
//Initial number of elements: 0

//Adding 6 elements
//Number of elements: 6
//Current contents: C A E B D F