using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Declare the generic class.
public class GenericList<T>
{
    public void Add(T input) { }
}
class TestGenericList
{

    private class ExampleClass { }

    /*Generic methods*/
    static void Swap<T>(ref T lhs, ref T rhs)
    {
        T temp;
        temp = lhs;
        lhs = rhs;
        rhs = temp;
    }

    public static void TestSwap()
    {
        int a = 1;
        int b = 2;

        Swap<int>(ref a, ref b);
        System.Console.WriteLine(a + " " + b);
    }



    /*methods 2 */
    static List<T> GetInitializedList<T>(T value, int count)
    {
        // This generic method returns a List with ten elements initialized.
        // ... It uses a type parameter.
        // ... It uses the "open type" T.
        List<T> list = new List<T>();
        for (int i = 0; i < count; i++)
        {
            list.Add(value);
        }
        return list;
    }

    
    static void Main()
    {
        // Declare a list of type int.
        GenericList<int> list1 = new GenericList<int>();
        list1.Add(1);

        // Declare a list of type string.
        GenericList<string> list2 = new GenericList<string>();
        list2.Add("");

        // Declare a list of type ExampleClass.
        GenericList<ExampleClass> list3 = new GenericList<ExampleClass>();
        list3.Add(new ExampleClass());



        /**/

        TestSwap();

        /**/

        // Use the generic method.
        // ... Specifying the type parameter is optional here.
        // ... Then print the results.
        List<bool> list1_ = GetInitializedList(true, 5);
        List<string> list2_ = GetInitializedList<string>("Perls", 3);
        foreach (bool value in list1_)
        {
            Console.WriteLine(value);
        }
        foreach (string value in list2_)
        {
            Console.WriteLine(value);
        }
    }
}