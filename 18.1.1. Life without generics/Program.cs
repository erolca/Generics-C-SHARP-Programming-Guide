using System;

class NonGen
{
    object ob;

    public NonGen(object o)
    {
        ob = o;
    }

    public object getob()
    {
        return ob;
    }

    public void showType()
    {
        Console.WriteLine("Type of ob is " + ob.GetType());
    }
}

class MainClass
{
    public static void Main()
    {
        NonGen iOb = new NonGen(102);
        iOb.showType();

        int v = (int)iOb.getob();
        Console.WriteLine("value: " + v);

        Console.WriteLine();

        NonGen strOb = new NonGen("Non-Generics Test");
        strOb.showType();

        String str = (string)strOb.getob();
        Console.WriteLine("value: " + str);
    }
}
//Type of ob is System.Int32
//value: 102

//Type of ob is System.String
//value: Non-Generics Test