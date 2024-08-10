using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Campaign : ICampaign
    {
        private readonly List<string> contributors;
        protected Campaign(string brand, double budget)
        {
            if (string.IsNullOrWhiteSpace(brand)) throw new ArgumentException(ExceptionMessages.BrandIsrequired);
            Brand = brand;
            Budget = budget;
            contributors = new();
            Contributors = contributors.AsReadOnly();
        }

        public string Brand { get; }
        public double Budget { get; private set; }
        public IReadOnlyCollection<string> Contributors { get; }
        public void Gain(double amount)
        {
            Budget += amount;
        }

        public void Engage(IInfluencer influencer)
        {
            contributors.Add(influencer.Username);
        }

        public override string ToString()
        {
            return $"{typeof(Campaign).Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {Contributors.Count}";
        }
    }
}
