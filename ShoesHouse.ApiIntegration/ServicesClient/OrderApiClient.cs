using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.Application.Interfaces;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ApiIntegration.ServicesClient
{
    public class OrderApiClient : IOrderApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderApiClient(IHttpClientFactory httpClientFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<OrderViewModel>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);
            var response = await client.GetAsync("/api/Orders");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<List<OrderViewModel>>(await response.Content.ReadAsStringAsync());
        }
    }
}
