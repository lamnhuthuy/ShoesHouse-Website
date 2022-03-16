using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.Utilities.Constants;
using ShoesHouse.ViewModels.Requests.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.WebApp.Controllers
{

    public class CartController : Controller
    {
        private readonly ICartApiClient _cartApiClient;

        public CartController(ICartApiClient cartApiClient)
        {
            _cartApiClient = cartApiClient;
        }

        [HttpPost]
        public async Task<JsonResult> AddToCart([FromBody] CartCreateRequest request)
        {
            var result = await _cartApiClient.Create(request);
            if (result == 1)
            {
                return Json(new { issucess = true });

            }
            return Json(new { issucess = false });
        }
        [HttpGet]
        public async Task<JsonResult> AmountInCart()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value;
                Guid user = Guid.Parse(userId);
                var amount = await _cartApiClient.AmountInCart(user);
                return Json(new { issucess = amount });
            }
            else
            {
                return Json(new { issucess = 0 });
            }
        }
        public async Task<IActionResult> Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value;
                Guid user = Guid.Parse(userId);
                var data = await _cartApiClient.GetAllByUserIdAsync(user);
                List<CartUpdateRequest> cartUpdateRequests = new List<CartUpdateRequest>();
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var cart = new CartUpdateRequest()
                        {
                            Amount = item.Amount,
                            IdProduct = item.ProductId,
                        };
                        cartUpdateRequests.Add(cart);
                    }
                }
                ViewBag.data = data;
                return View(cartUpdateRequests);

            }
            return View();
        }
    }
}
