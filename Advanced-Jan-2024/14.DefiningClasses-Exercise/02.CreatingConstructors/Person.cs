using System;
namespace DefiningClasses;

public class Person
{
    // 1st field
    private string name;
    private int age;

    // 2nd ctor
    public Person()
    {

    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // 3th property
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    //4th method


}


