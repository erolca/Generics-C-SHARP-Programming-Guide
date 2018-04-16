using System;
using System.Collections.Generic;

class MyStack<T>
{
    int MaxStack = 10;

    T[] StackArray;
    int StackPointer = 0;

    public MyStack()
    {
        StackArray = new T[MaxStack];
    }

    public void Push(T x)
    {
        if (StackPointer < MaxStack)
            StackArray[StackPointer++] = x;
    }

    public T Pop()
    {
        return (StackPointer > 0)
                    ? StackArray[--StackPointer]
                    : StackArray[0];
    }

    public void Print()
    {
        for (int i = StackPointer - 1; i >= 0; i--)
            Console.WriteLine(" Value: {0}", StackArray[i]);
    }
}

class MainClass
{
    static void Main()
    {
        MyStack<int> StackInt = new MyStack<int>();
        MyStack<string> StackString = new MyStack<string>();

        StackInt.Push(3);
        StackInt.Push(7);
        StackInt.Print();

        StackString.Push("This is fun");
        StackString.Push("Hi there! ");
        StackString.Print();
    }
}
//Value: 7
// Value: 3
// Value: Hi there!
// Value: This is fun