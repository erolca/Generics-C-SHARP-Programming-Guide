using System;

class A
{
}

class B : A
{
}

// Here, V must inherit T. 
class Gen<T, V> where V : T
{
}

class MainClass
{
    public static void Main()
    {
        Gen<A, B> x = new Gen<A, B>();

        // error 
        // Gen<B, A> y = new Gen<B, A>(); 

    }
}