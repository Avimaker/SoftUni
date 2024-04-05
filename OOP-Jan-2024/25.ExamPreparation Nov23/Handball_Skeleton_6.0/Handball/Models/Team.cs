using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handball.Models.Contracts;

namespace Handball.Models

{
    public class Team : ITeam
    {
        private string _name;
        private int _pointsEarned = 0;
        //private double _overallRating = 0;
        private List<IPlayer> _players;

        public Team(string name)
        {
            Name = name;
            //_pointsEarned = 0;
            _players = new List<IPlayer>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Team name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public int PointsEarned
        {
            get { return _pointsEarned; }
            private set { _pointsEarned = value; }
        }

        //public double OverallRating => this.Players.Count == 0 ? 0 : Math.Round(this._players.Average(p => p.Rating), 2); //кратък синтаксис

        public double OverallRating
        {
            get
            {
                if (_players.Count == 0)
                {
                    return 0;
                }
                return Math.Round(_players.Average(p => p.Rating), 2);
            }
        }

        //public IReadOnlyCollection<IPlayer> Players => _players.AsReadOnly();// кратък синтаксис

        public IReadOnlyCollection<IPlayer> Players
        {
            get { return _players.AsReadOnly(); }
        }

        //тук така добавям плеъри към отбора
        public void SignContract(IPlayer player)
        {
            _players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;
            foreach (var player in _players)
            {
                player.IncreaseRating();
            }
        }

        public void Lose()
        {
            foreach (var player in _players)
            {
                player.DecreaseRating();
            }
        }

        public void Draw()
        {
            PointsEarned += 1;
            //Players.FirstOrDefault(p => p.GetType().Name == nameof(Goalkeeper)).IncreaseRating();//кратък синтаксис

            IPlayer goalkeeper = _players.FirstOrDefault(p => p is Goalkeeper);
            if (goalkeeper != null)
            {
                goalkeeper.IncreaseRating();
            }

        }

        public override string ToString()
        {
            //long part тази част до сб трябва да отпадне ако ползваме краткия синтаксис
            //string playersToString = "none";

            //if (_players.Count > 0)
            //{
            //    playersToString = String.Join(", ", _players.Select(p => p.Name));
            //}


            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            sb.Append($"--Players: ");

            //short
            if (this.Players.Any())
            {
                var names = this.Players.Select(p => p.Name);
                sb.Append(string.Join(", ", names));
            }
            else
            {
                sb.Append("none");
            }

            return sb.ToString().TrimEnd();
        }

    }
}

