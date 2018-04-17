using System;

class ArrayUtils
{

    public static void print<T>(T e, T[] src)
    {
        for (int i = 0; i < src.Length; i++)
        {
            Console.WriteLine(src[i]);
        }
    }
}

class MainClass
{
    public static void Main()
    {
        int[] nums = { 1, 2, 3 };

        ArrayUtils.print(99, nums);

        Console.WriteLine();


        string[] strs = { "Generics", "are", "powerful." };

        ArrayUtils.print("in C#", strs);


        // invalid 
        // ArrayUtils.copyInsert(0.01, nums); 

    }
}
//1
//2
//3

//Generics
//are 
//powerful.