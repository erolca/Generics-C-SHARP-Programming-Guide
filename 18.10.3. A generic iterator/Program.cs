using System;
using System.Collections.Generic;

class MyClass<T>
{
    T[] array;

    public MyClass(T[] a)
    {
        array = a;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T obj in array)
            yield return obj;
    }
}

class MainClass
{
    public static void Main()
    {
        int[] nums = { 4, 3, 6, 4, 7, 9 };
        MyClass<int> mc = new MyClass<int>(nums);

        foreach (int x in mc)
            Console.Write(x + " ");

        Console.WriteLine();


        bool[] bVals = { true, true, false, true };
        MyClass<bool> mc2 = new MyClass<bool>(bVals);

        foreach (bool b in mc2)
            Console.Write(b + " ");

        Console.WriteLine();
    }
}
//4 3 6 4 7 9
//True True False True