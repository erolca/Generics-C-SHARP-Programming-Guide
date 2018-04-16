using System;
using System.Collections.Generic;


//	18.7.1.	Use the keys to obtain the values from a generic SortedList

class MainClass
{
    public static void Main()
    {
        SortedList<string, double> sl = new SortedList<string, double>();

        sl.Add("A", 7);
        sl.Add("B", 5);
        sl.Add("C", 4);
        sl.Add("D", 9);

        // Get a collection of the keys.  
        ICollection<string> c = sl.Keys;


        foreach (string str in c)
            Console.WriteLine("{0}, Salary: {1:C}", str, sl[str]);

        Console.WriteLine();
    }
}
//A, Salary: $7.00
//B, Salary: $5.00
//C, Salary: $4.00
//D, Salary: $9.00