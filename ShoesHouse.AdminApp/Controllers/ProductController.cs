using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.Utilities.Extensions;
using ShoesHouse.ViewModels.Requests.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.AdminApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            if (TempData["result"] != null)
            {
                if (TempData["result"].ToString() == "true")
                {
                    ViewBag.message = "Deleted category successfully.";
                }
                else ViewBag.message = "Category couldn't remove.";
            }

            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categoryVm = await _categoryService.GetAllAsync();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var catogory in categoryVm)
            {
                items.Add(new SelectListItem { Text = catogory.Name, Value = catogory.Id.ToString() });
            }
            ViewBag.MovieType = items;
            if (TempData["result"] != null)
            {
                if (TempData["result"].ToString() == "true")
                {
                    ViewBag.message = "Create product successfully.";
                }
                else ViewBag.message = "Product couldn't create.";
            }
            return View();
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _productService.CreateProductAsync(request);
            if (result)
            {
                TempData["result"] = "true";
            }
            else
            {
                TempData["result"] = "false";

            }
            return RedirectToAction("Create");
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (result)
            {
                TempData["result"] = "true";
            }
            else
            {
                TempData["result"] = "false";

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            ViewBag.category = await _categoryService.GetAllAsync();
            var productVm = new ProductUpdateRequest()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Description = product.Description,
                Size = product.Size,
            };
            ViewBag.productImg = product.ProductImages;
            if (TempData["result"] != null)
            {
                if (TempData["result"].ToString() == "true")
                {
                    ViewBag.message = "Update product successfully.";
                }
                else ViewBag.message = "Product couldn't update.";
            }
            return View(productVm);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(ProductUpdateRequest request)
        {
            var result = await _productService.UpdateProductAsync(request);
            if (result)
            {
                TempData["result"] = "true";
            }
            else
            {
                TempData["result"] = "false";

            }

            return RedirectToAction("Update");
            return View("Index");
        }
    }
}
