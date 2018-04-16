using System;

class Program
{
    static void Main()
    {
        // Example Action instances.
        // ... First example uses one parameter.
        // ... Second example uses two parameters.
        // ... Third example uses no parameter.
        // ... None have results.
        Action<int> example1 =
            (int x) => Console.WriteLine("Write {0}", x);
        Action<int, int> example2 =
            (x, y) => Console.WriteLine("Write {0} and {1}", x, y);
        Action example3 =
            () => Console.WriteLine("Done");
        // Call the anonymous methods.
        example1.Invoke(1);
        example2.Invoke(2, 3);
        example3.Invoke();

        
    }
}