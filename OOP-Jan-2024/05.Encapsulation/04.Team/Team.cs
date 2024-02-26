namespace PersonsInfo
{
    public class Team
    {
        ////var 1
        //private string name;
        //private List<Person> firstTeam = new();
        //private List<Person> reserveTeam = new();



        //public string Name { get; set; }

        //public Team(string name)
        //{
        //  Name = name;
        //}

        //public List<Person> ReserveTeam
        //{
        //	get { return this.reserveTeam; }
        //	private set { this.reserveTeam = value; }
        //}

        //public List<Person> FirstTeam
        //{
        //	get { return this.firstTeam; }
        //	private set { this.firstTeam = value; }
        //}

        //public void AddPlayer(Person person)
        //{
        //	if (person.Age < 40)
        //	{
        //		firstTeam.Add(person);
        //	}
        //	else
        //	{
        //		reserveTeam.Add(person);
        //	}
        //}

        //var 2
        private string name;
        private List<Person> firstTeam = new();
        private List<Person> reserveTeam = new();


        public string Name { get; set; }

        public Team(string name)
        {
            this.Name = name;
            //this.firstTeam = new List<Person>();// има го в полето
            //this.reserveTeam = new List<Person>();//има го в полето

        }

        public IReadOnlyCollection<Person> FirstTeam => this.firstTeam.AsReadOnly();// кратък начин за изписване

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return this.reserveTeam.AsReadOnly(); }
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

