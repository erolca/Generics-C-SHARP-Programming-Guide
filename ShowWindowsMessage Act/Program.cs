using System;
using System.Windows.Forms;
using System.Collections.Generic;

public class TestAction1
{
    public static void Main()
    {
        Action<string> messageTarget;

        if (Environment.GetCommandLineArgs().Length > 1)
            messageTarget = ShowWindowsMessage;
        else
            messageTarget = Console.WriteLine;

        messageTarget("Hello, World!");

        /**/
        List<String> names = new List<String>();
        names.Add("Bruce");
        names.Add("Alfred");
        names.Add("Tim");
        names.Add("Richard");

        // Display the contents of the list using the Print method.
        names.ForEach(Print);

        // The following demonstrates the anonymous method feature of C#
        // to display the contents of the list to the console.
        names.ForEach(delegate (String name)
        {
            Console.WriteLine(name);
        });
    }
    /*-1*/
    private static void ShowWindowsMessage(string message)
    {
        MessageBox.Show(message);
    }


    /*-2*/
    private static void Print(string s)
    {
        Console.WriteLine(s);
    }

}