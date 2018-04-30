using System;

class MyClass
{
}

class Test<T> where T : class
{
    T obj;

    public Test()
    {
        // Here T must be a reference type, 
        // which can be assigned the value null. 
        obj = null;
    }
}

class MainClass
{
    public static void Main()
    {
        // The following is OK because MyClass is a class. 
        Test<MyClass> x = new Test<MyClass>();

        // The next line is in error because int is a value type. 
        // Test<int> y = new Test<int>(); 
    }
}