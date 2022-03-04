using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.Utilities.Constants;
using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.Requests.Category;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ApiIntegration.ServicesClient
{
    public class CategoryApiClient : ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryApiClient(IHttpClientFactory httpClientFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CategoryViewModel> CreateCategoryAsync(CategoryCreateRequest request)
        {

            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            client.BaseAddress = new Uri(_config["BaseAddress"]);
            var response = await client.PostAsync($"/api/Categories", httpContent);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryViewModel>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/Categories/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<bool>(body);

            }
            return false;
        }

        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);
            var response = await client.GetAsync("/api/Categories");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<List<CategoryViewModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);
            var response = await client.GetAsync($"/api/Categories/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<CategoryViewModel>(await response.Content.ReadAsStringAsync());
        }

        public async Task<bool> UpdateCategoryAsync(CategoryUpdateRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            client.BaseAddress = new Uri(_config["BaseAddress"]);
            var response = await client.PutAsync($"/api/Categories", httpContent);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
            }
            return false;
        }
    }
}
