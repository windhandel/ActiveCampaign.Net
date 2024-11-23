namespace ActiveCampaign.Net.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.Message;

    public class MessageService : ActiveCampaignService
    {
        public MessageService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<Message?> AddMessageAsync(Message message)
        {
            var jsonResponse = await Send<Message>("message_add", message);
            return jsonResponse;
        }

        public async Task<bool> DeleteMessageAsync(int messageId)
        {
            var jsonResponse = await Send<Result>("message_delete", new { id = messageId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> DeleteMessagesAsync(List<int> messageIds)
        {
            var jsonResponse = await Send<Result>("message_delete_list", new { ids = string.Join(",", messageIds) });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<Message?> EditMessageAsync(Message message)
        {
            var jsonResponse = await Send<Message>("message_edit", message);
            return jsonResponse;
        }

        public async Task<List<Message>?> GetAllMessagesAsync()
        {
            var jsonResponse = await Get<List<Message>>("message_list");
            return jsonResponse;
        }

        public async Task<Message?> GetMessageByIdAsync(int messageId)
        {
            var jsonResponse = await Get<Message>("message_view", new { id = messageId });
            return jsonResponse;
        }

        public async Task<MessageTemplate?> AddMessageTemplateAsync(MessageTemplate template)
        {
            var jsonResponse = await Send<MessageTemplate>("message_template_add", template);
            return jsonResponse;
        }

        public async Task<bool> DeleteMessageTemplateAsync(int templateId)
        {
            var jsonResponse = await Send<Result>("message_template_delete", new { id = templateId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> DeleteMessageTemplatesAsync(List<int> templateIds)
        {
            var jsonResponse = await Send<Result>("message_template_delete_list", new { ids = string.Join(",", templateIds) });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<MessageTemplate?> EditMessageTemplateAsync(MessageTemplate template)
        {
            var jsonResponse = await Send<MessageTemplate>("message_template_edit", template);
            return jsonResponse;
        }

        public async Task<bool> ExportMessageTemplateAsync(int templateId)
        {
            var jsonResponse = await Send<Result>("message_template_export", new { id = templateId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> ImportMessageTemplateAsync(string templateData)
        {
            var jsonResponse = await Send<Result>("message_template_import", new { data = templateData });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<List<MessageTemplate>?> GetAllMessageTemplatesAsync()
        {
            var jsonResponse = await Get<List<MessageTemplate>>("message_template_list");
            return jsonResponse;
        }

        public async Task<MessageTemplate?> GetMessageTemplateByIdAsync(int templateId)
        {
            var jsonResponse = await Get<MessageTemplate>("message_template_view", new { id = templateId });
            return jsonResponse;
        }
    }
}
