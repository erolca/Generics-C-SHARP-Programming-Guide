using System;


//18.13.2.	A simple generic class with two type parameters: T and V

class TwoGen<T, V>
{
    T ob1;
    V ob2;

    public TwoGen(T o1, V o2)
    {
        ob1 = o1;
        ob2 = o2;
    }

    public void showTypes()
    {
        Console.WriteLine("Type of T is " + typeof(T));
        Console.WriteLine("Type of V is " + typeof(V));
    }

    public T getT()
    {
        return ob1;
    }

    public V getV()
    {
        return ob2;
    }
}

class MainClass
{
    public static void Main()
    {

        TwoGen<int, string> tgObj = new TwoGen<int, string>(1, "A");

        tgObj.showTypes();

        int v = tgObj.getT();
        Console.WriteLine("value: " + v);

        string str = tgObj.getV();
        Console.WriteLine("value: " + str);
    }
}
//Type of T is System.Int32
//Type of V is System.String
//value: 1
//value: A