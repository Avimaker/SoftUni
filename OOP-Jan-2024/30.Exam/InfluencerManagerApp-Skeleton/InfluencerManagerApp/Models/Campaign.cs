using System;
using InfluencerManagerApp.Models.Contracts;

namespace InfluencerManagerApp.Models
{
    public abstract class Campaign : ICampaign
    {
        public string _brand;
        private List<string> _contributors;

        protected Campaign(string brand, double budget)
        {
            Brand = brand;
            Budget = budget;
            _contributors = new List<string>();
        }

        public string Brand
        {
            get => _brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand is required.");
                }
                _brand = value;
            }
        }

        //prop
        public double Budget { get; private set; }

        public IReadOnlyCollection<string> Contributors => _contributors.AsReadOnly();

        public void Gain(double amount)
        {
            Budget += amount;//todo plus or times
        }

        public void Engage(IInfluencer influencer)
        {
          
            int campaignPrice = influencer.CalculateCampaignPrice();
            //todo to check
            //if (Budget > campaignPrice)
            //{
            //    _contributors.Add(influencer.Username);
            //    Budget -= campaignPrice;
            //}
            _contributors.Add(influencer.Username);
            Budget -= campaignPrice;
        }

        //todo not sure
        public override string ToString()
        {
            return $"{GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {_contributors}";
        }
    }
}
