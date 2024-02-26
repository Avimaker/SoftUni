namespace PersonsInfo
{
	public class Person
	{
		private string firstName;
		private string lastName;
		private int age;
		private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
			Salary = salary;
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

        public decimal Salary
        {
            get { return this.salary; }
            private set { this.salary = value; }
        }

        public override string ToString()
        {
			return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }

		public void IncreaseSalary(decimal percentage)
		{
			if (Age < 30)
			{
				Salary += Salary / 100 * percentage / 2; 
			}
			else
			{
                Salary += Salary / 100 * percentage;
            }
		}
    }
}

