using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

class MainClass
{
    static void Main()
    {
        Collection<int> numbers = new Collection<int>();
        numbers.Add(2);
        numbers.Add(9);

        Collection<string> strings = new Collection<string>();
        strings.Add("J");
        strings.Add("B");

        Collection< Collection<int> > colNumbers = new Collection< Collection<int> >();
        colNumbers.Add(numbers);

        IList<int> theNumbers = numbers;
        foreach (int i in theNumbers)
        {
            Console.WriteLine(i);
        }
    }
}
//2
//9