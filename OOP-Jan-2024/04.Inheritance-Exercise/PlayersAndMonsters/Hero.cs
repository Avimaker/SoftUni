﻿
namespace PlayersAndMonsters
{
	public abstract class Hero
	{

		private string username;
		private int level;

        public Hero(string username, int level)
        {
            Username = username;
            Level = level;
        }

        public string Username
		{
			get { return this.username; }
			set { this.username = value; }
		}

		public int Level
		{
			get { return this.level; }
			set { this.level = value; }
		}

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }

	}
}

