namespace ActiveCampaign.Net.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.Tracking;

    public class SiteEventTrackingService : ActiveCampaignService
    {
        public SiteEventTrackingService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var jsonResponse = await Send<Result>("track_event_delete", new { id = eventId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<List<Event>?> GetAllEventsAsync()
        {
            var jsonResponse = await Get<List<Event>>("track_event_list");
            return jsonResponse;
        }

        public async Task<bool> EditEventStatusAsync(int eventId, string status)
        {
            var jsonResponse = await Send<Result>("track_event_status_edit", new { id = eventId, status });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<string?> GetSiteTrackingCodeAsync()
        {
            var jsonResponse = await Get<string>("track_site_code");
            return jsonResponse;
        }

        public async Task<List<Site>?> GetAllSitesAsync()
        {
            var jsonResponse = await Get<List<Site>>("track_site_list");
            return jsonResponse;
        }

        public async Task<bool> EditSiteStatusAsync(int siteId, string status)
        {
            var jsonResponse = await Send<Result>("track_site_status_edit", new { id = siteId, status });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> AddSiteToWhitelistAsync(string site)
        {
            var jsonResponse = await Send<Result>("track_site_whitelist_add", new { site });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> DeleteSiteFromWhitelistAsync(string site)
        {
            var jsonResponse = await Send<Result>("track_site_whitelist_delete", new { site });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> AddEventAsync(Event eventObj)
        {
            var jsonResponse = await Send<Result>("track_event_add", eventObj);
            return jsonResponse?.ResultCode == 1;
        }
    }
}
