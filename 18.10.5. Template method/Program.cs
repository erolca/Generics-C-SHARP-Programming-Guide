/*Quote from: 

Book Accelerated C# 2005
    * By Trey Nash
    * ISBN: 1-59059-717-6
    * 432 pp.
    * Published: Aug 2006
    * Price: $39.99


*/


using System;
using System.Collections.Generic;

public class MyContainer<T> : IEnumerable<T>
{
    public void Add(T item)
    {
        impl.Add(item);
    }

    // Converter<TInput, TOutput> is a new delegate type introduced
    // in the .NET Framework that can be wired up to a method that
    // knows how to convert the TInput type into a TOutput type.
    public void Add<R>(MyContainer<R> otherContainer, Converter<R, T> converter)
    {
        foreach (R item in otherContainer)
        {
            impl.Add(converter(item));
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in impl)
        {
            yield return item;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private List<T> impl = new List<T>();
}

public class EntryPoint
{
    static void Main()
    {
        MyContainer<long> lContainer = new MyContainer<long>();
        MyContainer<int> iContainer = new MyContainer<int>();

        lContainer.Add(1);
        lContainer.Add(2);
        iContainer.Add(3);
        iContainer.Add(4);

        lContainer.Add(iContainer, EntryPoint.IntToLongConverter);

        foreach (long l in lContainer)
        {
            Console.WriteLine(l);
        }
    }

    static long IntToLongConverter(int i)
    {
        return i;
    }
}
//1
//2
//3
//4