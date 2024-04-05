
namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private const double Rating = 5.5;
        private const double IncreaseValue = 1.25;
        private const double DecreaseValue = 0.75;

        public ForwardWing(string name) : base(name, Rating)
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

