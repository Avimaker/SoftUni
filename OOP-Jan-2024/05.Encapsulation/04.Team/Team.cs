namespace PersonsInfo
{
	public class Team
	{
		private string name;
		private List<Person> firstTeam = new();
		private List<Person> reserveTeam = new();

		public string Name { get; set; }

		public Team(string name)
        {
            Name = name;
        }

        public List<Person> ReserveTeam
		{
			get { return this.reserveTeam; }
			private set { this.reserveTeam = value; }
		}

		public List<Person> FirstTeam
		{
			get { return this.firstTeam; }
			private set { this.firstTeam = value; }
		}

		public void AddPlayer(Person person)
		{
			if (person.Age < 40)
			{
				firstTeam.Add(person);
			}
			else
			{
				reserveTeam.Add(person);
			}
		}
	}
}

