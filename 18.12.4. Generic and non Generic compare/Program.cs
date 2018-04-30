using System;
using System.Collections;
using System.Collections.Generic;

public class MainClass
{

    public void NonGeneric(Stack stack)
    {
        foreach (object o in stack)
        {
            int number = (int)o;
            Console.WriteLine(number);
        }
    }

    public void Generic(Stack<int> stack)
    {
        foreach (int number in stack)
        {
            Console.WriteLine(number);
        }
    }

    public static void Main()
    {
        ;
    }

  

}


  
