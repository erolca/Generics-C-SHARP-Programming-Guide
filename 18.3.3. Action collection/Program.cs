using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Text;

class ActionCollection<T> : Collection<T>
{
    private Action<T> action;

    public ActionCollection(Action<T> action)
    {
        this.action = action;
    }

    protected override void InsertItem(int index, T item)
    {
        action(item);
        base.InsertItem(index, item);
    }
}

class MyClass<T>:Collection<T>
{

}


public class MainClass
{
    public static void Main()
    {
        ActionCollection<string> ac = new ActionCollection<string>(Console.WriteLine);
        ac.Add("console");

        //Action<string> messageTarget;
        ac = new ActionCollection<string>(ShowWindowsMessage);
        ac.Add("Show Windows Message");

      

    }

    private static void ShowWindowsMessage(string message)
    {
        MessageBox.Show(message);
    }

}