using Microsoft.AspNetCore.Mvc;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.ViewModels.Requests.Product;
using ShoesHouse.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index([FromQuery] GetProductPagingRequest request)
        {
            request.PageSize = 12;
            request.PageIndex = request.PageIndex > 0 ? request.PageIndex : 1;

            var products = await _productService.GetAllPagingAsync(request);
            var categories = await _categoryService.GetAllAsync();

            var viewModel = new ProductVm()
            {
                Products = products,
                Categories = categories
            };

            return View(viewModel);

        }
    }
}
