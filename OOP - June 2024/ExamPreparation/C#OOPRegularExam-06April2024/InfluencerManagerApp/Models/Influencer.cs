using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public class Influencer : IInfluencer
    {
        private List<string> participations;
        public Influencer(string username, int followers, double engagementRate)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
            if (followers < 0) throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
            Username = username;
            Followers = followers;
            EngagementRate = engagementRate;
            participations = new();
            Participations = participations.AsReadOnly();
            Income = 0.0;
        }

        public string Username { get; }
        public int Followers { get; }
        public double EngagementRate { get; }
        public double Income { get; private set; }
        public IReadOnlyCollection<string> Participations { get; }
        public void EarnFee(double amount)
        {
            Income += amount;
        }

        public void EnrollCampaign(string brand)
        {
            participations.Add(brand);
        }

        public void EndParticipation(string brand)
        {
            participations.Remove(brand);
        }

        public virtual int CalculateCampaignPrice()
        {
            return (int)(Followers * EngagementRate);
        }

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }
    }
}
