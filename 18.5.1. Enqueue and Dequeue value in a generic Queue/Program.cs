using System;
using System.Collections.Generic;

class MainClass
{
    public static void Main()
    {
        Queue<double> q = new Queue<double>();

        q.Enqueue(9.6);
        q.Enqueue(2.0);
        q.Enqueue(3.0);
        q.Enqueue(3.1);

        double sum = 0.0;
        Console.Write("Queue contents: ");
        while (q.Count > 0)
        {
            double val = q.Dequeue();
            Console.Write(val + " ");
            sum += val;
        }

        Console.WriteLine("\nTotal is " + sum);
    }
}
//Queue contents: 9.6 2 3 3.1
//Total is 17.7