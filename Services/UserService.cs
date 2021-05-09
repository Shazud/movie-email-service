using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MovieEmailService.Models;
using MovieEmailService.Settings;

namespace MovieEmailService.Services
{
    public class UserService : IUserService
    {
        private readonly UserServiceSettings _settings;
        private readonly HttpClient _client;

        public UserService(UserServiceSettings settings, HttpClient client)
        {
            _settings = settings;
            _client = client;
        }

        public async Task<User> GetUserByUsername(string email)
        {
            HttpResponseMessage res = _client.Send(new HttpRequestMessage(HttpMethod.Get, _settings.address + "/api/users/email/" + email));
            if(res.IsSuccessStatusCode){ 
                return await res.Content.ReadFromJsonAsync<User>();
            }
            return null;
        }

        public async Task<IEnumerable<User>> GetUsersSubscribed()
        {
            HttpResponseMessage res = _client.Send(new HttpRequestMessage(HttpMethod.Get, _settings.address + "/api/users/newsletter"));
            if(res.IsSuccessStatusCode){ 
                return await res.Content.ReadFromJsonAsync<IEnumerable<User>>();
            }
            return null;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            HttpResponseMessage res = _client.Send(new HttpRequestMessage(HttpMethod.Get, _settings.address + "/api/users/email"));
            if(res.IsSuccessStatusCode){ 
                return await res.Content.ReadFromJsonAsync<IEnumerable<User>>();
            }
            return null;
        }
    }
}