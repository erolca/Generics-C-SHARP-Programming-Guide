using System;
using System.Collections.Generic;

public class MainClass
{
    static void Main()
    {
        List<int> intList = new List<int>();
        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.Add(4);

        foreach (int n in CreateReverseIterator(intList))
        {
            Console.WriteLine(n);
        }
    }

    static IEnumerable<T> CreateReverseIterator<T>(IList<T> list)
    {
        int count = list.Count;
        for (int i = count - 1; i >= 0; --i)
        {
            yield return list[i];
        }
    }
}
//4
//3
//2
//1