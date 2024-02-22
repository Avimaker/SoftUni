using System;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public virtual int Age
        {
            get { return this.age; }
            set
            {
                if (value > 0)
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            //StringBuilder sb = new();
            ////sb.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));
            //sb.Append($"Name: {this.Name}, Age: {this.Age}");

            //return sb.ToString();

            return $"Name: {this.Name}, Age: {this.Age}";
        }

    }
}

