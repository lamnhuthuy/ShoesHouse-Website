using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesHouse.Application.Interfaces;
using ShoesHouse.ViewModels.Requests.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("BackToSchool")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBackToSchool()
        {
            var products = await _productService.GetBackToSchool();
            return Ok(products);
        }
        [HttpGet("Collection")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCollection()
        {
            var products = await _productService.GetBestChoice();
            return Ok(products);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.CreateAsync(request);
            return Ok(productId);
        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                var result = await _productService.DeleteAsync(productId);
                if (result == 0)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{productId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int productId)
        {
            try
            {
                var product = await _productService.GetByIdAsync(productId);
                if (product == null)
                {
                    return NotFound($"Cannot find a cake with Id: {product}");
                }

                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _productService.UpdateAsync(request);

                if (result == 0)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetProductPagingRequest request)
        {
            try
            {
                var data = await _productService.GetAllPagingAsync(request);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("LatestProduct")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestProduct()
        {
            try
            {
                var data = await _productService.GetLatestProduct();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}/{comment}/{user}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddComment(int id, string comment, Guid user)
        {
            try
            {
                var data = await _productService.AddComment(id, comment, user);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
