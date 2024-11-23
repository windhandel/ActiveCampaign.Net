using ActiveCampaign.Net.Models.Configuration;
using ActiveCampaign.Net.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace ActiveCampaign.Net.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddActiveCampaign(this IServiceCollection services, IConfiguration configuration)
        {
            var configurationModel = configuration.GetSection("ActiveCampaign").Get<ActiveCampaignConfiguration>();
            services.AddSingleton(configurationModel);

            string cleanedUrl = configurationModel.ApiUrl + (Regex.IsMatch(configurationModel.ApiUrl, "/$") ? string.Empty : "/") +
                (!Regex.IsMatch(configurationModel.ApiUrl, "https://www.activecampaign.com") ? "/admin" : string.Empty) +
                "/api.php?api_output=json";

            services.AddHttpClient(ActiveCampaignService.HttpClientName, httpClient =>
            {
                httpClient.BaseAddress = new Uri(cleanedUrl);
            });
            
            services.AddSingleton<CampaignService>();

            services.AddSingleton<ContactService>();

            services.AddSingleton<AccountService>();
        }
    }
}
