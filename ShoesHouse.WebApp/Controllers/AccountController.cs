using Microsoft.AspNetCore.Mvc;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.ViewModels.Requests.System.Users;
using ShoesHouse.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IOrderApiClient _orderApiClient;

        public AccountController(IUserApiClient userApiClient, IOrderApiClient orderApiClient)
        {
            _userApiClient = userApiClient;
            _orderApiClient = orderApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {

            var user = await _userApiClient.GetByIdAsync(id);
            var userupdate = new UserUpdateRequest()
            {
                UserName = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
            };
            var order = await _orderApiClient.GetByUserIdAsync(user.Id);
            ViewBag.order = order;

            return View(userupdate);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserUpdateRequest request)
        {

            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var userId = User.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value;
            Guid user = Guid.Parse(userId);
            request.Id = user;
            var result = await _userApiClient.Update(request);
            if (result.ResultObj == null)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }
            TempData["updateuser"] = "true";
            return RedirectToAction("Index", "Home");
        }
    }
}
