using System;
using System.Collections.Generic;



class MainClass
{
    public static void Main(string[] args)
    {
        // Create and use a Stack of Assembly Name objects
        Stack<MyClass> stack = new Stack<MyClass>();

        stack.Push(new MyClass());
       

        MyClass ass3 = stack.Pop();

        Console.WriteLine("\nPopped from stack: {0}", ass3);

        stack.Push(new MyClass());
        Console.WriteLine("\nPopped from stack: {0}", ass3);

    }
}


class MyClass
{
  static int id;

    public MyClass()
    {
        id++;

    }

    public override string ToString()
    {

        return "my class  id: " + id;
    }

}
//Popped from stack: my class