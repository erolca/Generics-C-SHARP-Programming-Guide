using System;
using System.ComponentModel;
using System.Text;

class TypeWithField<T>
{
    public static string field;

    public static void PrintField()
    {
        Console.WriteLine(field + ": " + typeof(T).Name);
    }

    static void Main()
    {
        TypeWithField<int>.field = "First";
        TypeWithField<int>.PrintField();
    }
}