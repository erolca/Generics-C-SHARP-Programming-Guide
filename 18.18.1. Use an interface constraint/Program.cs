using System;

class NotFoundException : ApplicationException { }

public interface IUserID
{
    string Number {
        get;
        set;}

    string Name {
        get;
        set;}
}

class Engineer : IUserID{
    string name;
    string number;

    public Engineer(string n, string num)
    {
        name = n;
        number = num;
    }

    // Implement IUserID 
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

class Manager : IUserID
{
    string name;
    string number;

    public Manager(string n, string num)
    {
        name = n;
        number = num;
    }

    // Implement IUserID 
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

class Guest
{

}

class IDList<T> where T : IUserID
{
    T[] idList;
    int end;

    public IDList()
    {
        idList = new T[10];
        end = 0;
    }

    public bool add(T newEntry)
    {
        if (end == 10)
            return false;

        idList[end] = newEntry;
        end++;

        return true;
    }

    public T findByName(string name)
    {

        for (int i = 0; i < end; i++)
        {
            if (idList[i].Name == name)
                return idList[i];
        }
        throw new NotFoundException();
    }

    public T findByNumber(string number)
    {
        for (int i = 0; i < end; i++)
        {
            if (idList[i].Number == number)
                return idList[i];
        }
        throw new NotFoundException();
    }
}

class MainClass
{
    public static void Main()
    {
        IDList<Engineer> plist = new IDList<Engineer>();
        plist.add(new Engineer("T", "1"));
        plist.add(new Engineer("G", "6"));
        plist.add(new Engineer("M", "9"));

        try
        {
            Engineer frnd = plist.findByName("G");
            Console.Write(frnd.Name + ": " + frnd.Number);
        }
        catch (NotFoundException)
        {
            Console.WriteLine("Not Found");
        }

        Console.WriteLine();

        IDList<Manager> plist2 = new IDList<Manager>();
        plist2.add(new Manager("H", "8"));
        plist2.add(new Manager("C", "2"));
        plist2.add(new Manager("N", "4"));

        try
        {
            Manager sp = plist2.findByNumber("4");
            Console.WriteLine(sp.Name + ": " + sp.Number);
        }
        catch (NotFoundException)
        {
            Console.WriteLine("Not Found");
        }

        // The following declaration is invalid 
        // because Guest does NOT implement IUserID. 
        // IDList<Guest> plist3 = new IDList<Guest>(); // Error! 
    }
}
//G: 6
//N: 4