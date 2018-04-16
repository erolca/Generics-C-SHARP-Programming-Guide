using System;
using System.Collections.Generic;

public class Employee : IComparable<Employee>
{
    private string name;
    private int level;

    private class AscendingLevelComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x == null && y == null)
                return 0;
            else if (x == null)
                return -1;
            else if (y == null)
                return 1;

            if (x == y)
                return 0;

            return x.level - y.level;
        }
    }

    public Employee(string name, int level)
    {
        this.name = name;
        this.level = level;
    }

    public static IComparer<Employee> LevelSorter
    {
        get { return new AscendingLevelComparer(); }
    }

    public override string ToString()
    {
        return string.Format("{0}: Level = {1}", name, level);
    }

    public int CompareTo(Employee other)
    {
        if (other == null)
            return 1;

        if (other == this)
            return 0;
        return string.Compare(this.name, other.name, true);
    }
}

public class MainClass
{
    public static void Main()
    {
        List<Employee> employeeList = new List<Employee>();


        /* Not: listede nesnelerin adresleri tutulmaktadır.*/
        employeeList.Add(new Employee("A", 1));
        employeeList.Add(new Employee("B", 5));
        employeeList.Add(new Employee("C", 2));
        employeeList.Add(new Employee("D", 8));
        employeeList.Add(new Employee("E", 5));


        Console.WriteLine("Unsorted employee list:");
        foreach (Employee n in employeeList)
        {
            Console.WriteLine("  " + n);
        }

        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Employee list sorted by name (default order):");
        employeeList.Sort();
        foreach (Employee n in employeeList)
        {
            Console.WriteLine("  " + n);
        }

        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Employee list sorted by level:");
        employeeList.Sort(Employee.LevelSorter);
        foreach (Employee n in employeeList)
        {
            Console.WriteLine("  " + n);
        }
    }
}
//Unsorted employee list:
//  A: Level = 1
//  B: Level = 5
//  C: Level = 2
//  D: Level = 8
//  E: Level = 5


//Employee list sorted by name(default order) :
//  A: Level = 1
//  B: Level = 5
//  C: Level = 2
//  D: Level = 8
//  E: Level = 5


//Employee list sorted by level:
//  A: Level = 1
//  C: Level = 2
//  E: Level = 5
//  B: Level = 5
//  D: Level = 8