namespace ActiveCampaign.Net.Services
{
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.Settings;

    public class SettingsService : ActiveCampaignService
    {
        public SettingsService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<Settings?> EditSettingsAsync(Settings settings)
        {
            var jsonResponse = await Send<Settings>("settings_edit", settings);
            return jsonResponse;
        }
    }
}
