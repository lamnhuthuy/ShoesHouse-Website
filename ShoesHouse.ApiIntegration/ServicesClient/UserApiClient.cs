using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.Utilities.Constants;
using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.Requests.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ApiIntegration.ServicesClient
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public UserApiClient(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<string> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(SystemConstants.MAIN_BASE_ADDRESS);
            var response = await client.PostAsync("/api/Users/authenticate", httpContent);

            var token = await response.Content.ReadAsStringAsync();

            return token;

        }
    }
}
