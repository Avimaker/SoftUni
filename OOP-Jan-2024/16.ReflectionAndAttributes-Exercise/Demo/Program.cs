using System.Reflection;

namespace Demo;
class Program
{
    static void Main(string[] args)
    {
        Type type = typeof(Person);

        PropertyInfo propertyInfo = type.GetProperty("Age");
        MethodInfo methodInfo = type.GetMethod("GetName");
        //FieldInfo fieldInfo = type.GetField("name", BindingFlags.Instance | BindingFlags.NonPublic);
        FieldInfo fieldInfo = type.GetField("name", (BindingFlags)36) ;

        ////var 1
        //Person instance = Activator.CreateInstance(type, new object[] {"Ivan", 18 }) as Person;

        //var 2 - имаме парам и ги изреждаме със запетайка
        Person instance = Activator.CreateInstance(type, "Ivan", 18 ) as Person;

        Console.WriteLine(instance.GetName());
 
        fieldInfo.SetValue(instance, "Georgi");// не е добре да се прави така

        Console.WriteLine(methodInfo.Invoke(instance, null));//ако нямам параметър в метода слагам null за да мога да го извикам с invoke

    }

    public class Person
    {
        private string name;

        public Person(string name, int age)
        {
            this.name = name;
            Age = age;
        }

        public int Age { get; set; }

        public string GetName() => name;
    }
}

