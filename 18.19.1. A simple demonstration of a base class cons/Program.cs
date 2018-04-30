using System;

class A
{
    public void hello()
    {
        Console.WriteLine("Hello");
    }
}

class B : A { }

class C { }

class Test<T> where T : A
{
    T obj;

    public Test(T o)
    {
        obj = o;
    }

    public void sayHello()
    {
        obj.hello();
    }
}

class MainClass
{
    public static void Main()
    {
        A a = new A();
        B b = new B();
        C c = new C();

        Test<A> t1 = new Test<A>(a);

        t1.sayHello();

        Test<B> t2 = new Test<B>(b);

        t2.sayHello();


        // The following is invalid because 
        // C does not inherit A. 
        //    Test<C> t3 = new Test<C>(c); // Error! 
    }
}
//Hello
//Hello