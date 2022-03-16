using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.ViewModels.Requests.Product;
using ShoesHouse.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.WebApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index([FromQuery] GetProductPagingRequest request)
        {
            request.Keyword = "";
            request.PageSize = 12;
            request.PageIndex = request.PageIndex > 0 ? request.PageIndex : 1;
            var latestProduct = await _productService.GetLatestProductAsync();
            var data = await _productService.GetAllPagingAsync(request);
            var homeVm = new HomeViewModel()
            {
                LatestProduct = latestProduct,
                Products = data,
            };
            return View(homeVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
