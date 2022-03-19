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
        private readonly IUserApiClient _userApiClient;

        public CartController(ICartApiClient cartApiClient, IUserApiClient userApiClient)
        {
            _cartApiClient = cartApiClient;
            _userApiClient = userApiClient;
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
                decimal total = 0;
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
                        total = total + item.Amount * item.OriginalPrice;
                    }
                }
                ViewBag.user = await _userApiClient.GetByIdAsync(user);
                ViewBag.data = data;
                ViewBag.total = total;
                return View(cartUpdateRequests);

            }
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> DeleteCart([FromBody] CartCreateRequest request)
        {
            var result = await _cartApiClient.DeleteCartAsync(request);
            decimal total = 0;
            if (result)
            {
                var userId = User.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value;
                Guid user = Guid.Parse(userId);
                var data = await _cartApiClient.GetAllByUserIdAsync(user);
                if (data.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        total = total + item.OriginalPrice * item.Amount;
                    }
                }
                return Json(new { issucess = true, total = total });

            }
            return Json(new { issucess = false });
        }
        [HttpPost]
        public async Task<JsonResult> ChangeTotal([FromBody] CartUpdateRequest request)
        {
            var result = await _cartApiClient.UpdateCartAsync(request);
            decimal total = 0;
            if (result)
            {
                var userId = User.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value;
                Guid user = Guid.Parse(userId);
                var data = await _cartApiClient.GetAllByUserIdAsync(user);
                if (data.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        total = total + item.OriginalPrice * item.Amount;
                    }
                }
                return Json(new { issucess = true, total = total });

            }
            return Json(new { issucess = false });
        }
        [HttpPost]
        public async Task<IActionResult> CheckOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value;
                Guid user = Guid.Parse(userId);
                var result = await _cartApiClient.CheckOut(user);
                if (result != 0)
                {
                    TempData["orderCart"] = "true";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Cart");
                }
            }
            return RedirectToAction("Index", "Cart");
        }

    }
}
