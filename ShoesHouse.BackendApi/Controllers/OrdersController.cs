using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesHouse.Application.Interfaces;
using ShoesHouse.ViewModels.Requests.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStatusAsync(UpdateStatusRequest request)
        {
            var result = await _orderService.UpdateStatusAsync(request);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] OrderCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderId = await _orderService.CreateOrderAsync(request);
            if (orderId == 0)
            {
                return BadRequest();
            }
            var data = await _categoryService.GetByIdAsync(categoryId);
            if (data == null)
            {
                return NotFound($"Cannot find a order with Id: {categoryId}");
            }
            return Ok(data);
        }
    }
}
