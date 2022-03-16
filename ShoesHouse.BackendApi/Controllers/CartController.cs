using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesHouse.Application.Interfaces;
using ShoesHouse.ViewModels.Requests.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CartCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cart = await _cartService.CreatCart(request);
            if (cart == 0)
            {
                return BadRequest();
            }

            return Ok(cart);
        }
        [HttpGet("AmountInCart/{id}")]
        public async Task<IActionResult> AmountInCart(Guid id)
        {
            var amount = await _cartService.AmountInCart(id);
            return Ok(amount);
        }
        [HttpGet("GetByUserId/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllByUserId(Guid id)
        {
            try
            {
                var cart = await _cartService.GetByUserIdAsync(id);
                if (cart == null)
                {
                    return NotFound($"Cannot find carts with IdUser: {id}");
                }

                return Ok(cart);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
