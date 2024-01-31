namespace DefiningClasses;

public class Family
{
    private List<Person> people;

    public List<Person> People
    {
        get { return this.people; }
        set { this.people = value; }
    }

    public Family()
    {
        people = new List<Person>(); //винаги когато ползвам лист трябва да си го инициализирам в конструктора
    }

    public Family(List<Person> people)
    {
        People = people;
    }

    public void AddMember(Person member)
    {
        this.People.Add(member);
    }

    public Person GetOldestMemeber()
    {
        return this.People.MaxBy(p => p.Age);
    }

}

