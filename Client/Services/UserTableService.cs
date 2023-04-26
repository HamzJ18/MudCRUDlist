using MudCRUDlist.Client.Services.Interface;
using MudCRUDlist.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace MudCRUDlist.Client.Services
{
    public class UserTableService : IUserTableService
    {
        private readonly HttpClient _httpClient;
        public UserTableService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UserTable> AddUser(UserTable entity)
        {
            var response = await _httpClient.PostAsJsonAsync("api/userinfo", entity);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new UserTable();
                }
                string s = await response.Content.ReadAsStringAsync();
                //return Enumerable.Empty<LookupTable>();
                return await response.Content.ReadFromJsonAsync<UserTable>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status code: {response.StatusCode} message: {message}");
            }
        }

        public async Task<UserTable> DeleteUser(string UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<UserTable> GetUser(string UserID)
        {
            try
            {

                var response = await _httpClient.GetAsync($"api/userinfo/{UserID}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return new UserTable();
                    }
                    string s = await response.Content.ReadAsStringAsync();
                    //return Enumerable.Empty<LookupTable>();
                    return await response.Content.ReadFromJsonAsync<UserTable>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }

            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }
        }
        public async Task<IEnumerable<UserTable>> GetUsers()
        {

            try
            {

                var response = await _httpClient.GetAsync("api/userinfo");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<UserTable>();
                    }
                    string s = await response.Content.ReadAsStringAsync();
                    //return Enumerable.Empty<LookupTable>();
                    return await response.Content.ReadFromJsonAsync<IEnumerable<UserTable>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }

            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }
        }
        public async Task<UserTable> UpdateUser(string UserId, UserTable entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/userinfo/{UserId}", entity);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new UserTable();
                }
                string s = await response.Content.ReadAsStringAsync();
                //return Enumerable.Empty<LookupTable>();
                return await response.Content.ReadFromJsonAsync<UserTable>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status code: {response.StatusCode} message: {message}");
            }
        }

    }
}
