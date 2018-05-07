using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        static void Main(string[] args)
        {

        Point<int> pInt = new Point<int>(10, 15);
        Point<double> pDouble = new Point<double>(55.5, 13.5);
        Console.WriteLine(pInt.ToString());
        Console.WriteLine();
        Console.WriteLine(pDouble.ToString());

        Console.ReadLine();

     }
}

//10 , 15

//55,5 , 13,5


