using System;
using BorderControl.Models.Interfaces;

namespace BorderControl.Models
{
	public class Citizen : IId
	{
		private string name;
		private int age;

        public Citizen(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
		public int Age { get; private set; }
    }
}

