namespace ActiveCampaign.Net.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.Contact;

    public class ContactService : ActiveCampaignService
    {
        public ContactService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<List<Contact>?> GetAllContactsAsync()
        {
            var jsonResponse = await Get<List<Contact>>("contact_list");
            return jsonResponse;
        }

        public async Task<Contact?> GetContactByIdAsync(int contactId)
        {
            var jsonResponse = await Get<Contact>("contact_view", new { id = contactId });
            return jsonResponse;
        }

        public async Task<Contact?> GetContactByEmailAsync(string email)
        {
            var jsonResponse = await Get<Contact>("contact_view_email", new { email });
            return jsonResponse;
        }

        public async Task<Contact?> GetContactByHashAsync(string hash)
        {
            var jsonResponse = await Get<Contact>("contact_view_hash", new { hash });
            return jsonResponse;
        }

        public async Task<Contact?> CreateContactAsync(Contact contact)
        {
            var jsonResponse = await Send<Contact>("contact_add", contact);
            return jsonResponse;
        }

        public async Task<Contact?> UpdateContactAsync(Contact contact)
        {
            var jsonResponse = await Send<Contact>("contact_edit", contact);
            return jsonResponse;
        }

        public async Task<bool> DeleteContactAsync(int contactId)
        {
            var jsonResponse = await Send<Result>("contact_delete", new { id = contactId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> DeleteContactsAsync(List<int> contactIds)
        {
            var jsonResponse = await Send<Result>("contact_delete_list", new { ids = string.Join(",", contactIds) });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> AddContactNoteAsync(int contactId, string note)
        {
            var jsonResponse = await Send<Result>("contact_note_add", new { id = contactId, note });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> EditContactNoteAsync(int noteId, string note)
        {
            var jsonResponse = await Send<Result>("contact_note_edit", new { id = noteId, note });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> DeleteContactNoteAsync(int noteId)
        {
            var jsonResponse = await Send<Result>("contact_note_delete", new { id = noteId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> AddContactTagAsync(int contactId, int tagId)
        {
            var jsonResponse = await Send<Result>("contact_tag_add", new { contact = contactId, tag = tagId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> RemoveContactTagAsync(int contactId, int tagId)
        {
            var jsonResponse = await Send<Result>("contact_tag_remove", new { contact = contactId, tag = tagId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<List<ContactAutomation>?> GetContactAutomationsAsync(int contactId)
        {
            var jsonResponse = await Get<List<ContactAutomation>>("contact_automation_list", new { id = contactId });
            return jsonResponse;
        }

        public async Task<Paginator?> GetContactPaginatorAsync(int page, int limit)
        {
            var jsonResponse = await Get<Paginator>("contact_paginator", new { page, limit });
            return jsonResponse;
        }

        public async Task<Contact?> SyncContactAsync(Contact contact)
        {
            var jsonResponse = await Send<Contact>("contact_sync", contact);
            return jsonResponse;
        }
    }
}
