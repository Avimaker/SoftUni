
namespace PersonsInfo
{
	public class Person
	{
		private string firstName;
		private string lastName;
		private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
		{
			get { return this.firstName; }
			private set { this.firstName = value; }
		}

		public string LastName
		{
			get { return this.lastName; }
			private set { this.lastName = value; }
		}

		public int Age
		{
			get { return this.age; }
			private set { this.age = value; }
		}

        public override string ToString()
        {
			return $"{FirstName} {LastName} is {Age} years old.";
        }

    }
}

