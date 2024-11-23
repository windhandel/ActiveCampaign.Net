namespace ActiveCampaign.Net.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.Deal;
    using Tasks = ActiveCampaign.Net.Models.Task;

    public class TaskService : ActiveCampaignService
    {
        public TaskService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<Tasks.Task?> AddTaskAsync(Tasks.Task task)
        {
            var jsonResponse = await Send<Tasks.Task>("deal_task_add", new
            {
                title = task.Title,
                deal_id = task.DealId,
                type = task.Type,
                due_date = task.DueDate.ToString("o")
            });
            return jsonResponse;
        }

        public async Task<Tasks.Task?> EditTaskAsync(Tasks.Task task)
        {
            var jsonResponse = await Send<Tasks.Task>("deal_task_edit", new
            {
                id = task.Id,
                title = task.Title,
                deal_id = task.DealId,
                type = task.Type,
                due_date = task.DueDate.ToString("o")
            });
            return jsonResponse;
        }

        public async Task<TaskType?> AddTaskTypeAsync(TaskType taskType)
        {
            var jsonResponse = await Send<TaskType>("deal_tasktype_add", new
            {
                title = taskType.Title
            });
            return jsonResponse;
        }

        public async Task<bool> DeleteTaskTypeAsync(int taskTypeId)
        {
            var jsonResponse = await Send<Result>("deal_tasktype_delete", new { id = taskTypeId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<TaskType?> EditTaskTypeAsync(TaskType taskType)
        {
            var jsonResponse = await Send<TaskType>("deal_tasktype_edit", new
            {
                id = taskType.Id,
                title = taskType.Title
            });
            return jsonResponse;
        }
    }
}

