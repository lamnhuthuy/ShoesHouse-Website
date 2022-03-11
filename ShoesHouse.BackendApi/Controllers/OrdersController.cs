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
        [HttpPut("UpdateStatus")]
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
            var data = await _orderService.GetByIdAsync(orderId);
            if (data == null)
            {
                return NotFound($"Cannot find a order with Id: {orderId}");
            }
            return Ok(data);
        }
        [HttpGet("{orderId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int orderId)
        {
            try
            {
                var order = await _orderService.GetByIdAsync(orderId);
                if (order == null)
                {
                    return NotFound($"Cannot find a cake with Id: {orderId}");
                }

                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("UserId/{UserId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByUserId(Guid UserId)
        {
            try
            {
                var order = await _orderService.GetByUserIdAsync(UserId);
                if (order == null)
                {
                    return NotFound($"Cannot find a cake with Id: {UserId}");
                }

                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{orderId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int orderId)
        {
            try
            {
                var result = await _orderService.DeleteOrderAsync(orderId);
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
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] OrderUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _orderService.UpdateOrderAsync(request);

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

        [HttpDelete("{orderId}/{productId}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteOrderDetails(int orderId, int productId)
        {
            try
            {
                var result = await _orderService.DeleteOrderDetails(orderId, productId);
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

        [HttpPost("CreateOrderDetails")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrderDetailsAsync([FromBody] OrderDetailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderId = await _orderService.CreateOrderDetailsAsync(request);
            if (orderId == 0)
            {
                return BadRequest();
            }
            return Ok(orderId);
        }
    }
}
