using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

public class MainClass
{
    public static void Main()
    {
        IEnumerable<string> enumerable = new string[] { "A", "B", "C" };

        foreach (string s in enumerable)
            Console.WriteLine(s);

        IEnumerator<string> enumerator = enumerable.GetEnumerator();
        while (enumerator.MoveNext())
        {
            string s = enumerator.Current;
            Console.WriteLine(s);
        }
    }
}
//A
//B
//C
//A
//B
//C