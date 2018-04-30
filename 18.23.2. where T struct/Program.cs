using System.Collections.Generic;

public class MyValueList<T> where T : struct
{
    private List<T> imp = new List<T>();

    public void Add(T v)
    {
        imp.Add(v);
    }
}

public class MainClass
{
    static void Main()
    {
        MyValueList<int> intList = new MyValueList<int>();

        intList.Add(123);

        // CAN'T DO THIS.
        // MyValueList<object> objList = new MyValueList<object>();
    }
}