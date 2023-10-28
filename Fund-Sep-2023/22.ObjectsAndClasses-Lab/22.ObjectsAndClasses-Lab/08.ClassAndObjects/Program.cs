namespace _08.ClassAndObjects;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        numbers.Capacity = 5; //properties
        numbers.Add(3);

        // вграден клас
        Random rndNum = new Random();


        //съсздаване на инстанция на Person
        Person person1 = new Person(); // person 1 - object - така го създаваме
        // персон1 е референтна стойност, което означава, че може да я сменяме по всяко време


        // I. първи начин за създаване на обект през инстанция
        string firstName = Console.ReadLine();
        person1.FirstName = firstName; // може и направо  CR
        person1.LastName = "Tomov";
        person1.Age = 47;
        person1.Walk();

        string test = person1.FirstName; // мога да присвоявам
        TestMetod(person1.LastName); // може да участва в методи

        // II. втори начин за създаване на обект е когато създаваме
        // инстанцията да попълним директно
        Person person2 = new Person()
        {
            FirstName = "Iva",
            LastName = "Tomova",
            Age = 43
        };


        /* III. трети начин за създаване на обект е когато създаваме
        classa да си добавим и конструктор. Това са скобките () на методите
        и тогава като почнеме да създаваме инстанцията ни кара да попълним
        директно и то всичко което поискаме в конструктора, иначе се кара*/

        Person person3 = new Person("Evgeni", "Tomov");

        Console.WriteLine(person1.Age);

    }
    static void TestMetod(string name)  // metod
    {
        Console.WriteLine("hello" + name);
    }
}

class Person //така създаваме class
{
    /*като извикаме метод със скобите и гледаме колко overloada има и от
    параметри може да изберем - т.е. може да имаме няколко конструктора
    ако искаме да задължим да се попълва инфо махаме празния конструктор*/

    public Person() // в случая имаме празен constructor, може да не го пишем
    {

    }

    //public Person(string firstname) // constructor, задължава ни да пишем
    //{
    //    FirstName = firstname;
    //}

    public Person(string firstName, string lastName) // constructor, задължава ни да пишем
    {
        FirstName = firstName;
        LastName = lastName;
        Grades = new List<int>();
    }


    //така създаваме properties (prop tab tab)
    public string FirstName { get; set; } //get & set са методи
    public string LastName { get; set; }
    public int Age { get; set; } // public [type] [PropName] { get; set; }
    public List<int> Grades { get; set; }

    //така създаваме метод
    public void Walk()
    {
        Console.WriteLine($"{FirstName} walking");
    }
}

