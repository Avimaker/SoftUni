using System;
namespace InfluencerManagerApp.Models
{
    public class BusinessInfluencer : Influencer
    {
        private const double EngagementRate = 3.0;
        private const double Factor = 0.15;

        public BusinessInfluencer(string username, int followers) : base(username, followers, EngagementRate)
        {
        }

        public override int CalculateCampaignPrice()
        {
            double price = Followers * EngagementRate * Factor;
            return (int)Math.Floor(price);
        }
    }
}

