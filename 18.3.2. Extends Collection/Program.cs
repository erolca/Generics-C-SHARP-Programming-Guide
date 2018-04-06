using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

class ConverterCollection<T> : Collection<T>
{
    private Converter<T, T> convert;

    public ConverterCollection(Converter<T, T> convert)
    {
        this.convert = convert;
    }

    protected override void InsertItem(int index, T item)
    {
        base.InsertItem(index, convert(item));
    }
}

public class MainClass
{
    public static void Main()
    {
        ConverterCollection<string> c = new ConverterCollection<string>(
            delegate (string s) { return s.ToUpper(); });
        c.Add("Hello");
        c.Add("World!");

        foreach (string s in c)
            Console.WriteLine(s);
    }
}
//HELLO
//WORLD!