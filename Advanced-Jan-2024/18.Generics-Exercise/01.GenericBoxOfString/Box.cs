using System;
using System.Text;

namespace GenericBoxOfString;

public class Box<T>
{
    //private List<T> items = new List<T>();//short way
    private List<T> items;

    public Box()
    {
        items = new List<T>();//if i use short way - this line have to be deleted
    }

    public void Add(T item)
    {
        items.Add(item);
    }

    public override string ToString()
    {
        StringBuilder sb = new();

        foreach (var item in items)
        {
            sb.AppendLine($"{typeof(T)}: {item.ToString()}");
        }

        return sb.ToString().TrimEnd();
    }

}


