namespace ActiveCampaign.Net.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.Webhook;

    public class WebhookService : ActiveCampaignService
    {
        public WebhookService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<Webhook?> AddWebhookAsync(Webhook webhook)
        {
            var jsonResponse = await Send<Webhook>("webhook_add", webhook);
            return jsonResponse;
        }

        public async Task<bool> DeleteWebhookAsync(int webhookId)
        {
            var jsonResponse = await Send<Result>("webhook_delete", new { id = webhookId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<Webhook?> EditWebhookAsync(Webhook webhook)
        {
            var jsonResponse = await Send<Webhook>("webhook_edit", webhook);
            return jsonResponse;
        }

        public async Task<List<string>?> GetWebhookEventsAsync()
        {
            var jsonResponse = await Get<List<string>>("webhook_events");
            return jsonResponse;
        }

        public async Task<List<Webhook>?> GetAllWebhooksAsync()
        {
            var jsonResponse = await Get<List<Webhook>>("webhook_list");
            return jsonResponse;
        }

        public async Task<Webhook?> GetWebhookByIdAsync(int webhookId)
        {
            var jsonResponse = await Get<Webhook>("webhook_view", new { id = webhookId });
            return jsonResponse;
        }
    }
}
