
namespace Handball.Models
{
    public class CenterBack : Player
    {
        private const double Rating = 4.0;
        private const double IncreaseValue = 1.00;
        private const double DecreaseValue = 1.00;

        public CenterBack(string name) : base(name, Rating)
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

