using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.ViewModels.Requests.Order;
using ShoesHouse.ViewModels.ViewModels;
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
        [HttpPost]
        public async Task<JsonResult> UpdateStatus([FromBody] UpdateStatusRequest request)
        {
            var result = await _orderApiClient.UpdateStatusAsync(request);
            if (result)
            {
                return Json(new { status = true });

            }
            return Json(new { status = false });
        }
    }
}
