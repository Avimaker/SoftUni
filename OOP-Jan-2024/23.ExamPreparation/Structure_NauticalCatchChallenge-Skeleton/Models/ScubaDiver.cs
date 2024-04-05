using System;
namespace NauticalCatchChallenge.Models
{
	public class ScubaDiver : Diver
	{
        private const int BaseOxygen = 540;

        public ScubaDiver(string name) : base(name, BaseOxygen)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.3, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = BaseOxygen;
        }
    }
}

