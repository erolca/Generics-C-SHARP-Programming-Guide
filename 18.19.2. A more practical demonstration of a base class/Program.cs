using System;


//18.19.2.	A more practical demonstration of a base class constraint

class NotFoundException : ApplicationException { }

class UserID
{
    string name;
    string number;

    public UserID(string n, string num)
    {
        name = n;
        number = num;
    }

    public string Number
    {
        get { return number; }
        set { number = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

class Employee : UserID
{
    public Employee(string n, string num) : base(n, num)
    {

    }
}

class Manager : UserID
{
    public Manager(string n, string num) :
      base(n, num)
    { }
}

class Guest
{
}

class IDList<T> where T : UserID
{
    T[] userIDList;
    int end;

    public IDList()
    {
        userIDList = new T[10];
        end = 0;
    }

    public bool add(T newEntry)
    {
        if (end == 10) return false;

        userIDList[end] = newEntry;
        end++;

        return true;
    }

    public T findByName(string name)
    {
        for (int i = 0; i < end; i++)
        {
            if (userIDList[i].Name == name)
                return userIDList[i];

        }
        throw new NotFoundException();
    }

    public T findByNumber(string number)
    {

        for (int i = 0; i < end; i++)
        {
            if (userIDList[i].Number == number)
                return userIDList[i];
        }
        throw new NotFoundException();
    }
}

class MainClass
{
    public static void Main()
    {
        IDList<Employee> plist = new IDList<Employee>();
        plist.add(new Employee("T", "1"));
        plist.add(new Employee("G", "6"));
        plist.add(new Employee("M", "5"));

        try
        {
            Employee frnd = plist.findByName("T");
            Console.Write(frnd.Name + ": " + frnd.Number);
        }
        catch (NotFoundException)
        {
            Console.WriteLine("Not Found");
        }

        Console.WriteLine();

        IDList<Manager> plist2 = new IDList<Manager>();
        plist2.add(new Manager("G", "8"));
        plist2.add(new Manager("C", "9"));
        plist2.add(new Manager("N", "2"));

        try
        {
            Manager sp = plist2.findByNumber("8");
            Console.WriteLine(sp.Name + ": " + sp.Number);
        }
        catch (NotFoundException)
        {
            Console.WriteLine("Not Found");
        }
    }
}
//T: 1
//G: 8