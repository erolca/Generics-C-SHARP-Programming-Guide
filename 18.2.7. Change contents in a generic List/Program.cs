using System;
using System.Collections.Generic;


//18.2.7.	Change contents in a generic List using array indexing

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

        Console.WriteLine("Change first three elements");
        lst[0] = 'X';
        lst[1] = 'Y';
        lst[2] = 'Z';

        Console.Write("Contents: ");
        foreach (char c in lst)
            Console.Write(c + " ");
        Console.WriteLine();
    }
}
//Initial number of elements: 0

//Adding 6 elements
//Number of elements: 6
//Change first three elements
//Contents: X Y Z B D F