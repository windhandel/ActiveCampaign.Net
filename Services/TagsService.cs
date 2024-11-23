namespace ActiveCampaign.Net.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.Tag;

    public class TagsService : ActiveCampaignService
    {
        public TagsService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<List<Tag>?> GetAllTagsAsync()
        {
            var jsonResponse = await Get<List<Tag>>("tags_list");
            return jsonResponse;
        }
    }
}
