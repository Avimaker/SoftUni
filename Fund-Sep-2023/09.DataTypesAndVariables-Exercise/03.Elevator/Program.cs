int persons = int.Parse(Console.ReadLine());
int capacity = int.Parse(Console.ReadLine());

int course = persons / capacity;
int addCourse = persons % capacity;


if (addCourse != 0 && addCourse < capacity)
{
    course++;

}

Console.WriteLine(course);