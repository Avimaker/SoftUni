using System;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Models;

public class Citizen : IId, IName, IBirthdate
{
    public Citizen(string id, string name, int age, string birthdate)
    {
        Id = id;
        Name = name;
        Age = age;
        Birthdate = birthdate;
    }

    public string Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Birthdate { get; private set; }
}

