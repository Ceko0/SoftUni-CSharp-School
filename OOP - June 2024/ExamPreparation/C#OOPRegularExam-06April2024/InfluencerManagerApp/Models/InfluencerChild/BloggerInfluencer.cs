namespace InfluencerManagerApp.Models.InfluencerChild
{
    public class BloggerInfluencer : Influencer
    {
        private const double BIEngagementRate = 2.0;
        private const double BIFactor = 0.2;

        public BloggerInfluencer(string username, int followers)
            : base(username, followers, BIEngagementRate)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)(base.CalculateCampaignPrice() * BIFactor);
        }
    }
}
