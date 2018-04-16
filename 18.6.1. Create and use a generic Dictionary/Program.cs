using System;
using System.Reflection;
using System.Collections.Generic;



class MainClass
{
    public static void Main(string[] args)
    {
        Dictionary<string, MyClass> MyClassDictionary = new Dictionary<string, MyClass>();

        MyClassDictionary.Add("Crypto", new MyClass());

        MyClass myClass = MyClassDictionary["Crypto"];

        Console.WriteLine("Got from dictionary: {0}", myClass);



    }
}
class MyClass
{

    public override string ToString()
    {

        return "my class";
    }

}
//Got from dictionary: my class