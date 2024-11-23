namespace ActiveCampaign.Net.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.Deal;

    public class PipelineService : ActiveCampaignService
    {
        public PipelineService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<Pipeline?> AddPipelineAsync(Pipeline pipeline)
        {
            var postData = new Dictionary<string, string>
                {
                    { "title", pipeline.Title },
                    { "currency", pipeline.Currency }
                };

            var jsonResponse = await Send<Pipeline>("deal_pipeline_add", postData);
            return jsonResponse;
        }

        public async Task<bool> DeletePipelineAsync(int pipelineId)
        {
            var postData = new Dictionary<string, string> { { "id", pipelineId.ToString() } };
            var jsonResponse = await Send<Result>("deal_pipeline_delete", postData);
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<Pipeline?> EditPipelineAsync(Pipeline pipeline)
        {
            var postData = new Dictionary<string, string>
                {
                    { "id", pipeline.Id.ToString() },
                    { "title", pipeline.Title },
                    { "currency", pipeline.Currency }
                };

            var jsonResponse = await Send<Pipeline>("deal_pipeline_edit", postData);
            return jsonResponse;
        }

        public async Task<List<Pipeline>?> GetAllPipelinesAsync()
        {
            var jsonResponse = await Get<List<Pipeline>>("deal_pipeline_list");
            return jsonResponse;
        }
    }
}

