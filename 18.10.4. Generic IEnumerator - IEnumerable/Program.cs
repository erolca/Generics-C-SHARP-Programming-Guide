using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class StringEnumerator : IEnumerator<string>
{
    string[] Strings; int Position = -1;

    public string Current
    {
        get
        {
            return Strings[Position];
        }
    }

    object IEnumerator.Current
    {
        get
        {
            return Strings[Position];
        }
    }

    public bool MoveNext()
    {
        if (Position < Strings.Length - 1)
        {
            Position++;
            return true;
        }
        else
            return false;
    }

    public void Reset()
    {
        Position = -1;
    }

    public void Dispose() { }

    public StringEnumerator(string[] strings)
    {
        Strings = new string[strings.Length];
        for (int i = 0; i < strings.Length; i++)
            Strings[i] = strings[i];
    }
}

class MyStrings : IEnumerable<string>
{
    string[] Strings = { "AAA", "BBB", "CCC" };

    public IEnumerator<string> GetEnumerator()
    {
        return new StringEnumerator(Strings);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new StringEnumerator(Strings);
    }
}

class Program
{
    static void Main()
    {
        MyStrings mc = new MyStrings();
        foreach (string st in mc)
            Console.Write("{0}  ", st);
        Console.WriteLine("");
    }
}
//AAA BBB  CCC