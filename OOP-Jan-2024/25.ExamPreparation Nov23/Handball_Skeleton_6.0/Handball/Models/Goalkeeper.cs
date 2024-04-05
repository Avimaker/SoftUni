 namespace Handball.Models
{
    public class Goalkeeper : Player
    {
        private const double Rating = 2.5;
        private const double IncreaseValue = 0.75;
        private const double DecreaseValue = 1.25;

        public Goalkeeper(string name) : base(name, Rating)
        {
        }

        public override void DecreaseRating()
        {
            base.Rating -= DecreaseValue;
            if (base.Rating < 1)
            {
                base.Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            base.Rating += IncreaseValue;
            if (base.Rating > 10)
            {
                base.Rating = 10;
            }
        }
    }
}

