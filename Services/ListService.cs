namespace ActiveCampaign.Net.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.Contact;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="ListService" />
    /// </summary>
    public class ListService : ActiveCampaignService
    {
        public ListService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<List<BasicContactList>?> GetAllListsAsync()
        {
            var jsonResponse = await Get<List<BasicContactList>>("list_list");
            return jsonResponse;
        }

        public async Task<BasicContactList?> GetListByIdAsync(int listId)
        {
            var jsonResponse = await Get<BasicContactList>("list_view", new { id = listId });
            return jsonResponse;
        }

        public async Task<BasicContactList?> CreateListAsync(BasicContactList list)
        {
            var jsonResponse = await Send<BasicContactList>("list_add", list);
            return jsonResponse;
        }

        public async Task<BasicContactList?> UpdateListAsync(BasicContactList list)
        {
            var jsonResponse = await Send<BasicContactList>("list_edit", list);
            return jsonResponse;
        }

        public async Task<bool> DeleteListAsync(int listId)
        {
            var jsonResponse = await Send<Result>("list_delete", new { id = listId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> DeleteListsAsync(List<int> listIds)
        {
            var jsonResponse = await Send<Result>("list_delete_list", new { ids = string.Join(",", listIds) });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<Field?> AddFieldAsync(Field field)
        {
            var jsonResponse = await Send<Field>("list_field_add", field);
            return jsonResponse;
        }

        public async Task<bool> DeleteFieldAsync(int fieldId)
        {
            var jsonResponse = await Send<Result>("list_field_delete", new { id = fieldId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<Field?> EditFieldAsync(Field field)
        {
            var jsonResponse = await Send<Field>("list_field_edit", field);
            return jsonResponse;
        }

        public async Task<Field?> ViewFieldAsync(int fieldId)
        {
            var jsonResponse = await Get<Field>("list_field_view", new { id = fieldId });
            return jsonResponse;
        }

        public async Task<Paginator?> GetListPaginatorAsync(int page, int limit)
        {
            var jsonResponse = await Get<Paginator>("list_paginator", new { page, limit });
            return jsonResponse;
        }
    }
}
