using Microsoft.AspNetCore.Mvc;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.AdminApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IOrderApiClient _orderApiClient;
        public UserController(IUserApiClient userApiClient, IOrderApiClient orderApiClient)
        {
            _userApiClient = userApiClient;
            _orderApiClient = orderApiClient;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _userApiClient.GetAllAsync();
            return View(data);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var user = await _userApiClient.GetByIdAsync(id);
            var order = await _orderApiClient.GetByUserIdAsync(id);
            var UserDt = new UserDetailsViewModel()
            {
                OrderViewModel = order,
                UserViewModel = user,
            };
            return View(UserDt);
        }
    }
}
