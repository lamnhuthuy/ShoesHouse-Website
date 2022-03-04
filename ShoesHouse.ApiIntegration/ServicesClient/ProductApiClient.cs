using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.Utilities.Constants;
using ShoesHouse.ViewModels.Requests.Product;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ApiIntegration.ServicesClient
{
    public class ProductApiClient : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductApiClient(IHttpClientFactory httpClientFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateProductAsync(ProductCreateRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            client.BaseAddress = new Uri(_config["BaseAddress"]);
            var requestContent = new MultipartFormDataContent();
            if (request.FileUploads != null)
            {
                foreach (var file in request.FileUploads)
                {

                    byte[] data;
                    using (var br = new BinaryReader(file.OpenReadStream()))
                    {
                        data = br.ReadBytes((int)file.OpenReadStream().Length);
                    }
                    ByteArrayContent bytes = new ByteArrayContent(data);
                    requestContent.Add(bytes, "FileUploads", file.FileName);
                }
            }
            requestContent.Add(new StringContent(request.Size.ToString()), "Size");
            requestContent.Add(new StringContent(request.CategoryId.ToString()), "CategoryId");
            requestContent.Add(new StringContent(request.Price.ToString()), "Price");
            requestContent.Add(new StringContent(request.OriginalPrice.ToString()), "OriginalPrice");
            requestContent.Add(new StringContent(request.Stock.ToString()), "Stock");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "Name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Description) ? "" : request.Description.ToString()), "Description");
            var response = await client.PostAsync($"/api/products/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/Products/{productId}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<bool>(body);

            }
            return false;
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);
            var response = await client.GetAsync("/api/Products");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<List<ProductViewModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ProductViewModel> GetByIdAsync(int productId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["BaseAddress"]);
            var response = await client.GetAsync($"/api/Products/{productId}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ProductViewModel>(await response.Content.ReadAsStringAsync());
        }
    }
}
