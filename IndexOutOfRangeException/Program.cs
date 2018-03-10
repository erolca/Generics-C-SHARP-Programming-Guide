using System;
/*
C# Indexer:
An Indexer is a special type of property that allows a class or structure to be accessed
the same way as array for its internal collection.It is same as property except that it defined with
this keyword with square bracket and paramters.
*/
class StringDataStore
{

    private string[] strArr = new string[10]; // internal data storage

    public StringDataStore()
    {

    }

    public string this[int index]
    {
        get
        {
            if (index < 0 && index >= strArr.Length)
                throw new IndexOutOfRangeException("Cannot store more than 10 objects");

            return strArr[index];
        }

        set
        {
            if (index < 0 && index >= strArr.Length)
                throw new IndexOutOfRangeException("Cannot store more than 10 objects");

            strArr[index] = value;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        StringDataStore strStore = new StringDataStore();

        strStore[0] = "One";
        strStore[1] = "Two";
        strStore[2] = "Three";
        strStore[3] = "Four";

        for (int i = 0; i < 10; i++)
            Console.WriteLine(strStore[i]);
    }
}