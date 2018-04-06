using System.Collections.Generic;
using System;


class MainClass
{
    public static void Main(string[] args)
    {

        List<MyClass> list = new List<MyClass>();

        list.Add(new MyClass());

        MyClass ass2 = list[0];

        Console.WriteLine("\nFound in list: {0}", ass2);


        /*******/
        List<string> dinosaurs = new List<string>();
        dinosaurs.Add("Tyrannosaurus");
        dinosaurs.Add("Amargasaurus");
        dinosaurs.Add("Mamenchisaurus");
        dinosaurs.Add("Deinonychus");
        dinosaurs.Add("Compsognathus");
    }
}
class MyClass
{

    public override string ToString()
    {

        return "my class";
    }

}
//Found in list: my class