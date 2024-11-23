namespace ActiveCampaign.Net.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.Deal;

    public class StageService : ActiveCampaignService
    {
        public StageService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<Stage?> AddStageAsync(Stage stage)
        {
            var jsonResponse = await Send<Stage>("deal_stage_add", new
            {
                title = stage.Title,
                pipeline = stage.Pipeline,
                order = stage.Order
            });
            return jsonResponse;
        }

        public async Task<bool> DeleteStageAsync(int stageId)
        {
            var jsonResponse = await Send<Result>("deal_stage_delete", new { id = stageId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<Stage?> EditStageAsync(Stage stage)
        {
            var jsonResponse = await Send<Stage>("deal_stage_edit", new
            {
                id = stage.Id,
                title = stage.Title,
                pipeline = stage.Pipeline,
                order = stage.Order
            });
            return jsonResponse;
        }

        public async Task<List<Stage>?> GetAllStagesAsync()
        {
            var jsonResponse = await Get<List<Stage>>("deal_stage_list");
            return jsonResponse;
        }
    }
}

