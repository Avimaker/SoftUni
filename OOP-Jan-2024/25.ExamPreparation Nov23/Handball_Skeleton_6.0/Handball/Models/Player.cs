using System;
using System.Text;
using Handball.Models.Contracts;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string _name;
        private string _team;
        private double _rating;

        protected Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public double Rating
        {
            get { return _rating; }
            protected set { _rating = value; }// protected сетер защото ще го променяме пре метода, който тук е абстрактен и за да имаме достъп от децата !!!
        }

        public string Team
        {
            get { return _team; }
            private set { _team = value; }
        }

        //добавяме договор с отбор към инфото на играча
        public void JoinTeam(string name)
        {
            Team = name;
        }

        public abstract void IncreaseRating();

        public abstract void DecreaseRating();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}: {Name}");//този клас ще се наследява и затова взимаме с рефлешън името на класа
            sb.AppendLine($"--Rating: {Rating}");

            return sb.ToString().TrimEnd();
        }

    }
}

