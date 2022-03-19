using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoesHouse.AdminApp.Models;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoesHouse.AdminApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IOrderApiClient _orderApiClient;
        private readonly IProductService _productService;
        private readonly IUserApiClient _userApiClient;
        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IOrderApiClient orderApiClient, IProductService productService, IUserApiClient userApiClient)
        {
            _logger = logger;
            _categoryService = categoryService;
            _orderApiClient = orderApiClient;
            _productService = productService;
            _userApiClient = userApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            ViewBag.avt = claims.Where(x => x.Type == "Avartar").FirstOrDefault().Value;
            var listcate = await _categoryService.GetAllAsync();
            var listpr = await _productService.GetAllAsync();
            var listorder = await _orderApiClient.GetAllAsync();
            var listuser = await _userApiClient.GetAllAsync();
            ViewBag.CategoryAmount = listcate.Count();
            ViewBag.ProductAmount = listpr.Count();
            ViewBag.OrderAmount = listorder.Count();
            ViewBag.UserAmount = listuser.Count();

            return View();
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
