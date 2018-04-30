using System;

class MyClass
{
}

// Construct a default object of T. 
class Test<T>
{
    public T obj;

    public Test()
    {
        // obj must be a reference type. 
        // obj = null; 

        // This statement works for both  
        // reference and value types. 
        obj = default(T);
    }
}

class MainClass
{
    public static void Main()
    {
        Test<MyClass> x = new Test<MyClass>();

        if (x.obj == null)
            Console.WriteLine("x.obj is null.");

        Test<int> y = new Test<int>();

        if (y.obj == 0)
            Console.WriteLine("y.obj is 0.");
    }
}
//x.obj is null.
//y.obj is 0.