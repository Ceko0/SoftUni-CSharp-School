using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.CampaignChild;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Models.InfluencerChild;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IInfluencer> influencers = new InfluencerRepository();
        private readonly IRepository<ICampaign> campaigns = new CampaignRepository();
        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            Dictionary<string, Func<string, int, IInfluencer>> influencerTypes = new()
            {
                { nameof(BusinessInfluencer), (username, followers) => new BusinessInfluencer(username, followers) },
                { nameof(BloggerInfluencer), (username, followers) => new BloggerInfluencer(username, followers) },
                { nameof(FashionInfluencer), (username, followers) => new FashionInfluencer(username, followers) }
            };

            if (!influencerTypes.TryGetValue(typeName, out var createInfluencer))
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);

            IInfluencer influencer = createInfluencer(username, followers);

            if (influencers.FindByName(username) != null)
                return string.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));

            influencers.AddModel(influencer);
            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            Dictionary<string, Func<string, ICampaign>> campaignTypes = new()
            {
                { nameof(ProductCampaign), (brand) => new ProductCampaign(brand ) },
                { nameof(ServiceCampaign), (brand) => new ServiceCampaign(brand) }
            };
            if (!campaignTypes.TryGetValue(typeName, out var createCampaign))
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            ICampaign campaign = createCampaign(brand);
            foreach (var campaignsModel in campaigns.Models)
            {
                if (campaignsModel.Brand == campaign.Brand)
                    return string.Format(OutputMessages.CampaignDuplicated, brand);
            }



            campaigns.AddModel(campaign);
            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer influencer = influencers.FindByName(username);
            if (influencer == null)
                return string.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository), username);
            ICampaign campaign = campaigns.FindByName(brand);
            if (campaign == null)
                return string.Format(OutputMessages.CampaignNotFound, brand);
            if (campaign.Contributors.FirstOrDefault(username) != null)
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            if (!((campaign is ProductCampaign && (influencer is BusinessInfluencer || influencer is FashionInfluencer)) ||
                  (campaign is ServiceCampaign && (influencer is BusinessInfluencer || influencer is BloggerInfluencer))))
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            if (campaign.Budget < influencer.CalculateCampaignPrice())
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            influencer.EarnFee(influencer.CalculateCampaignPrice());
            influencer.EnrollCampaign(brand);
            campaign.Engage(influencer);
            campaign.Gain(-influencer.CalculateCampaignPrice());
            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign campaign = campaigns.FindByName(brand);
            if (campaign == null) return OutputMessages.InvalidCampaignToFund;
            if (amount <= 0) return OutputMessages.NotPositiveFundingAmount;
            campaign.Gain(amount);
            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string CloseCampaign(string brand)
        {
            ICampaign campaign = campaigns.FindByName(brand);
            if (campaign == null) return string.Format(OutputMessages.InvalidCampaignToClose);
            if (campaign.Budget <= 10_000) return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            foreach (string username in campaign.Contributors)
            {
                IInfluencer influencer = influencers.FindByName(username);
                influencer.EarnFee(2000);
                influencer.EnrollCampaign(campaign.Brand);
            }

            campaigns.RemoveModel(campaign);
            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = influencers.FindByName(username);

            if (influencer == null)
                return string.Format(OutputMessages.InfluencerNotSigned, username);

            if (influencer.Participations.Any() != null)
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            influencers.RemoveModel(influencer);
            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string ApplicationReport()
        {
            IOrderedEnumerable<IInfluencer> sortedInfluencers = influencers.Models.OrderByDescending(i => i.Income)
                .ThenByDescending(i => i.Followers);


            StringBuilder report = new StringBuilder();

            foreach (var influencer in sortedInfluencers)
            {
                report.AppendLine(influencer.ToString());

                var activeCampaigns = campaigns.Models
                    .Where(c => c.Contributors.Any(p => p == influencer.Username))
                    .OrderBy(c => c.Brand)
                    .ToList();

                if (activeCampaigns.Any())
                {
                    report.AppendLine("Active Campaigns:");
                    foreach (var campaign in activeCampaigns)
                    {
                        report.AppendLine($"--{campaign}");
                    }
                }
            }

            return report.ToString();
        }
    }
}
