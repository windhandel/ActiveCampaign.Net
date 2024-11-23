namespace ActiveCampaign.Net.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using Tasks = ActiveCampaign.Net.Models.Task;

    public class TasksService : ActiveCampaignService
    {
        public TasksService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<Tasks.Task?> GetTaskByIdAsync(int taskId)
        {
            var jsonResponse = await Get<Tasks.Task>("tasks_get", new { id = taskId });
            return jsonResponse;
        }
    }
}
