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
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return View(product);
        }
        [HttpGet]
        public async Task<JsonResult> AddComment([FromQuery] int id, [FromQuery] string comment)
        {
            var userId = User.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value;
            Guid user = Guid.Parse(userId);
            var result = await _productService.AddComment(id, comment, user);
            if (result != 0)
            {
                return Json(new { issucess = true });
            }
            return Json(new { issucess = true });
        }
    }
}
