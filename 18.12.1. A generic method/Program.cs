using System;

class ArrayUtils
{

    public static bool isBigger<T>(T[] src, T[] target)
    {
        // See if target array is big enough. 
        if (target.Length < src.Length + 1)
            return false;
        return true;
    }
}

class GenMethDemo
{



  


    public static void Main()
    {
        int[] nums = { 1, 2, 3 };
        int[] nums2 = new int[4];


        // Operate on an int array. 
        bool b = ArrayUtils.isBigger(nums, nums2);
       // bool b = ArrayUtils.isBigger<int>(nums, nums2);

        Console.WriteLine(b);

        string[] strs = { "Generics", "are", "powerful." };
        string[] strs2 = new string[4];

        b = ArrayUtils.isBigger(strs, strs2);


        Console.WriteLine(b);

    }
}
//True
//True