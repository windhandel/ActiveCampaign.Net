namespace ActiveCampaign.Net.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.Segment;

    public class SegmentService : ActiveCampaignService
    {
        public SegmentService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<List<Segment>?> GetAllSegmentsAsync()
        {
            var jsonResponse = await Get<List<Segment>>("segment_list");
            return jsonResponse;
        }
    }
}
