using System;
using System.Diagnostics;

/*
 * The Action was slower to call than the method from the abstract class reference. 
 * If you can use abstract classes instead of Actions, this will be faster.
 * Func nesnesi paremetre alir ve geriye bir result döndürür.
 * Action nesnesi parametre alir ve geriye bir result döndürmez.
 */

class Program
{
    const int _max = 100000000;
    static void Main()
    {
        // Create Action delegate for Method1.
        Action<int> action = new Action<int>(Method1);

        var s1 = Stopwatch.StartNew();
        for (int i = 0; i < _max; i++)
        {
            // Direct call.
            Method1(5);
        }
        s1.Stop();
        var s2 = Stopwatch.StartNew();
        for (int i = 0; i < _max; i++)
        {
            // Delegate call.
           // action.Invoke(5);
            action(5);
        }
        s2.Stop();
        Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000 * 1000) /
            _max).ToString("0.00 ns"));
        Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000 * 1000) /
            _max).ToString("0.00 ns"));
        Console.Read();
    }

    static void Method1(int param)
    {
        // Dummy.
        if (param == -1)
        {
            throw new Exception();
        }
    }
}


