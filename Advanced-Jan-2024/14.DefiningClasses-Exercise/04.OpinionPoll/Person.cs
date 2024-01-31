namespace DefiningClasses;

public class Person
{
    // 1st field
    private string name;
    private int age;

    // 2nd ctor
    public Person()
    {
        this.Name = "No name";
        this.Age = 1;
    }

    public Person(int age) : this()
    {
        Age = age;
    }

    public Person(string name, int age) : this(age)
    {
        Name = name;
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


