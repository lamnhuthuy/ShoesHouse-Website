using Microsoft.AspNetCore.Mvc;
using ShoesHouse.ApiIntegration.InterfacesClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.AdminApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApiClient;

        public UserController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _userApiClient.GetAllAsync();
            return View(data);
        }
    }
}
