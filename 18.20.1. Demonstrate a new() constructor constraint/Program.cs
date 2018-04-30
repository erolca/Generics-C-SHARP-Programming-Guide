using System;

class MyClass
{

    public MyClass()
    {
    }
}

class Test<T> where T : new()
{
    T obj;

    public Test()
    {
        obj = new T(); // create a T object 
    }
}

class MainClass
{
    public static void Main()
    {
        Test<MyClass> x = new Test<MyClass>();

    }
}