using System;
using System.Collections.Generic;
using System.Collections;

class MainClass
{
    public static void Main()
    {
        Stack<string> st = new Stack<string>();

        st.Push("One");
        st.Push("Two");
        st.Push("Three");
        st.Push("Four");
        st.Push("Five");

        while (st.Count > 0)
        {
            string str = st.Pop();
            Console.Write(str + " ");
        }

        Console.WriteLine();

        Stack stCollection = new Stack();
        stCollection.Push(1);
        stCollection.Push(2);
        foreach (int i in stCollection)
            Console.Write(i + " ");



    }
}
//Five Four Three Two One