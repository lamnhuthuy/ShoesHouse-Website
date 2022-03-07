using Microsoft.AspNetCore.Mvc;
using ShoesHouse.ApiIntegration.InterfacesClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.AdminApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApiClient _orderApiClient;

        public OrderController(IOrderApiClient orderApiClient)
        {
            _orderApiClient = orderApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderApiClient.GetAllAsync();
            return View(orders);
        }
    }
}
