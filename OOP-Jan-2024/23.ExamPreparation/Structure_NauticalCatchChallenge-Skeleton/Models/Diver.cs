using System;
using System.Xml.Linq;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> caughtFish;
        private double competitionPoints;
        private bool hasHealthIssues;

        public Diver(string name, int oxygenLevel)
        {
            this.Name = name;
            this.OxygenLevel = oxygenLevel;
            caughtFish = new List<string>();
        } 

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                this.name = value;
            }
        }

        public int OxygenLevel
        {
            get { return this.oxygenLevel; }
            protected set
            {
                if (value <= 0)
                {
                    hasHealthIssues = true;
                    value = 0;
                }
                else
                {
                    this.oxygenLevel = value;
                }

            }
        }

        public IReadOnlyCollection<string> Catch
        {
            get { return caughtFish.AsReadOnly(); }
        }

        public double CompetitionPoints
        {
            get { return this.competitionPoints; }
            //set { this.competitionPoints = value; }
        }

        public bool HasHealthIssues
        {
            get { return this.hasHealthIssues; }
            private set { this.hasHealthIssues = value; }
        }


        //methods
        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            this.caughtFish.Add(fish.Name);
            competitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            HasHealthIssues = !HasHealthIssues;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {caughtFish.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}

