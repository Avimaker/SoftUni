using System;
namespace InfluencerManagerApp.Models
{
	public class FashionInfluencer : Influencer
	{
        private const double EngagementRate = 4.0;
        private const double Factor = 0.1;

        public FashionInfluencer(string username, int followers) : base(username, followers, EngagementRate)
        {
        }

        public override int CalculateCampaignPrice()
        {
            double price = Followers * EngagementRate * Factor;
            return (int)Math.Floor(price);
        }
    }
}

