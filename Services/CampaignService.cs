namespace ActiveCampaign.Net.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.Campaign;

    public class CampaignService : ActiveCampaignService
    {
        public CampaignService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<List<Campaign>?> GetAllCampaignsAsync()
        {
            var jsonResponse = await Get<List<Campaign>>("campaign_list");
            return jsonResponse;
        }

        public async Task<Campaign?> GetCampaignByIdAsync(int campaignId)
        {
            var jsonResponse = await Get<Campaign>("campaign_view", new { id = campaignId });
            return jsonResponse;
        }

        public async Task<Campaign?> CreateCampaignAsync(Campaign campaign)
        {
            var jsonResponse = await Send<Campaign>("campaign_create", campaign);
            return jsonResponse;
        }

        public async Task<Campaign?> UpdateCampaignAsync(Campaign campaign)
        {
            var jsonResponse = await Send<Campaign>("campaign_edit", campaign);
            return jsonResponse;
        }

        public async Task<bool> DeleteCampaignAsync(int campaignId)
        {
            var jsonResponse = await Send<Result>("campaign_delete", new { id = campaignId });
            return jsonResponse?.ResultCode == 1;
        }
    }
}
