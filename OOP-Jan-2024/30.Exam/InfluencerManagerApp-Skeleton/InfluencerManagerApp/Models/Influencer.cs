using System;
using System.Security.Principal;
using System.Xml.Linq;
using InfluencerManagerApp.Models.Contracts;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private string _username;
        private int _followers;
        public double engagementRate; //?
        private double _income = 0; //ctror?
        private List<string> _participations;

        protected Influencer(string username, int followers, double engagementRate)
        {
            Username = username;
            Followers = followers;
            EngagementRate = engagementRate;
            _participations = new List<string>();
        }

        public string Username
        {
            get => _username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username is required.");
                }
                _username = value;
            }
        }

        public int Followers
        {
            get { return _followers; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Followers count cannot be a negative number.");
                }
                _followers = value;
            }
        }

        //?
        public double EngagementRate { get; private set; }

        //?
        public double Income
        {
            get { return _income; }
            private set { _income = value; }
        }

        //repository
        public IReadOnlyCollection<string> Participations => _participations.AsReadOnly();

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }

        public void EarnFee(double amount)
        {
            Income += amount;
        }

        //todo
        public void EnrollCampaign(string brand)
        {
            _participations.Add(brand);
        }

        //todo
        public void EndParticipation(string brand)
        {
            _participations.Remove(brand);
        }

        //todo price
        public abstract int CalculateCampaignPrice();
        
    }
}

