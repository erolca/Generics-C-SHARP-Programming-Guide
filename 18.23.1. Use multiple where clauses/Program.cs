using System;

class Gen<T, V> where T : class
                where V : struct
{
    T ob1;
    V ob2;

    public Gen(T t, V v)
    {
        ob1 = t;
        ob2 = v;
    }
}

class MainClass
{
    public static void Main()
    {
        Gen<string, int> obj = new Gen<string, int>("test", 11);

        // wrong because bool is not a reference type. 
        // Gen<bool, int> obj = new Gen<bool, int>(true, 11); 

    }
}