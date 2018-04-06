using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;

/*Reflection sayesinde çalıştığınız objelere ait verileri çalışma anında(run-time) okuyup düzenleyebilir */

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}

class GenericTypeReflection
{
    static void Main()
    {
        var user = new User
        {
            Id = 1,
            Name = "Ahmet",
            Surname = "Kakıcı"
        };
        /*İstediğimiz özellik veya özellikleri aldığımıza göre artık bu özelliklerin değerlerini okuma
         * ve bu değerleri güncelleme işlemlerini yapabiliriz.
         * Bunun için PropertyInfo sınıfında bulunan GetValue ve SetValue fonksiyonlarını kullanacağız.*/

        var nameProperty = user.GetType().GetProperty("Name");
        var name = nameProperty.GetValue(user, null);
        nameProperty.SetValue(user, "ahmeTT", null);
        name = nameProperty.GetValue(user, null);



        string listTypeName = "System.Collections.Generic.List";

        Type defByName = Type.GetType(listTypeName);

        Type closedByName = Type.GetType(listTypeName + "[System.String]");
        Type closedByMethod = defByName.MakeGenericType(typeof(string));
        Type closedByTypeof = typeof(List<string>);

        Console.WriteLine(closedByMethod == closedByName);
        Console.WriteLine(closedByName == closedByTypeof);

        Type defByTypeof = typeof(List<>);
        Type defByMethod = closedByName.GetGenericTypeDefinition();

        Console.WriteLine(defByMethod == defByName);
        Console.WriteLine(defByName == defByTypeof);
    }
}