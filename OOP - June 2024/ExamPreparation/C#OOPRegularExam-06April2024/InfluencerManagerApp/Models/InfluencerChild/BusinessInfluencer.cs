namespace InfluencerManagerApp.Models.InfluencerChild
{
    public class BusinessInfluencer : Influencer
    {
        private const double BIEngagementRate = 3.0;
        private const double BIFactor = 0.15;
        public BusinessInfluencer(string username, int followers) 
            : base(username, followers, BIEngagementRate)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)(base.CalculateCampaignPrice() * BIFactor);
        }
    }
}
