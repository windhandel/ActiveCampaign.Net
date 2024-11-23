namespace ActiveCampaign.Net.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.User;

    public class UserService : ActiveCampaignService
    {
        public UserService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<User?> AddUserAsync(User user)
        {
            var jsonResponse = await Send<User>("user_add", user);
            return jsonResponse;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var jsonResponse = await Send<Result>("user_delete", new { id = userId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> DeleteUsersAsync(List<int> userIds)
        {
            var jsonResponse = await Send<Result>("user_delete_list", new { ids = string.Join(",", userIds) });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<User?> EditUserAsync(User user)
        {
            var jsonResponse = await Send<User>("user_edit", user);
            return jsonResponse;
        }

        public async Task<List<User>?> GetAllUsersAsync()
        {
            var jsonResponse = await Get<List<User>>("user_list");
            return jsonResponse;
        }

        public async Task<User?> GetCurrentUserAsync()
        {
            var jsonResponse = await Get<User>("user_me");
            return jsonResponse;
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            var jsonResponse = await Get<User>("user_view", new { id = userId });
            return jsonResponse;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var jsonResponse = await Get<User>("user_view_email", new { email });
            return jsonResponse;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            var jsonResponse = await Get<User>("user_view_username", new { username });
            return jsonResponse;
        }
    }
}
