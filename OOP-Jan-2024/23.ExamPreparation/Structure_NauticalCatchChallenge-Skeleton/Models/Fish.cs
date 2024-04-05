using System;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish

    {
        private string name;
        private double points;
        private int timeToCatch;

        public Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            TimeToCatch = timeToCatch;
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
                    throw new ArgumentException(ExceptionMessages.FishNameNull);
                }
                this.name = value;
            }
        }

        public double Points
        {
            get { return this.points; }
            private set
            {
                if (points < 1 || points > 10)
                {
                    throw new ArgumentException(ExceptionMessages.PointsNotInRange);
                }
                this.points = value;
            }
        }

        public int TimeToCatch
        {
            get { return this.timeToCatch; }
            private set { this.timeToCatch = value; }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }

    }
}

