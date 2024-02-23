using System;
namespace Zoo
{
    public abstract class Animal
    {
        private string name;

        public Animal(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

    }
}

