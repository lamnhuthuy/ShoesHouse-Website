using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesHouse.Application.Interfaces;
using ShoesHouse.ViewModels.Requests.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Categories = await _categoryService.GetAllAsync();
            return Ok(Categories);
        }
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetById(int categoryId)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(categoryId);
                if (category == null)
                {
                    return NotFound($"Cannot find a cake with Id: {categoryId}");
                }

                return Ok(category);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryId = await _categoryService.CreateAsync(request);
            if (categoryId == 0)
            {
                return BadRequest();
            }
            var data = await _categoryService.GetByIdAsync(categoryId);
            if (data == null)
            {
                return NotFound($"Cannot find a cake with Id: {categoryId}");
            }
            return Ok(data);
        }
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            try
            {
                var result = await _categoryService.DeleteAsync(categoryId);
                if (result == 0)
                {
                    return NotFound($"Cannot find a cake with Id: {categoryId}");
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _categoryService.UpdateAsync(request);

                if (result == 0)
                {
                    return BadRequest();
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
