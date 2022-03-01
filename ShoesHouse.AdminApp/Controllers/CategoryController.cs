using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.Utilities.Constants;
using ShoesHouse.ViewModels.Requests.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.AdminApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        public async Task<IActionResult> Index()
        {

            var data = await _categoryService.GetAllAsync();
            if (TempData["result"] != null)
            {
                if (TempData["result"].ToString() == "true")
                {
                    ViewBag.message = "Deleted category successfully.";
                }
                else ViewBag.message = "Category couldn't remove.";
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.message = "unsuccessfully";
            var result = await _categoryService.DeleteCategoryAsync(id);
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
            var category = await _categoryService.GetByIdAsync(id);
            var categoryVm = new CategoryUpdateRequest() { Id = category.Id, Name = category.Name, Description = category.Description };
            if (TempData["result"] != null)
            {
                if (TempData["result"].ToString() == "true")
                {
                    ViewBag.message = "Updated category successfully.";
                }
                else ViewBag.message = "Category couldn't update.";
            }
            return View(categoryVm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateRequest request)
        {
            var result = await _categoryService.UpdateCategoryAsync(request);
            if (result)
            {
                TempData["result"] = "true";
            }
            else
            {
                TempData["result"] = "false";

            }

            return RedirectToAction("Update");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (TempData["result"] != null)
            {
                if (TempData["result"].ToString() == "true")
                {
                    ViewBag.message = "Create category successfully.";
                }
                else ViewBag.message = "category couldn't create.";
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _categoryService.CreateCategoryAsync(request);
            if (result != null)
            {
                TempData["result"] = "true";
            }
            else
            {
                TempData["result"] = "false";

            }
            return RedirectToAction("Create");
        }
    }
}
