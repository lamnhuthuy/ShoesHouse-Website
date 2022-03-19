using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoesHouse.ApiIntegration.InterfacesClient;
using ShoesHouse.ViewModels.Requests.Cart;
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
        private readonly IUserApiClient _userApiClient;
        private readonly ICartApiClient _cartApiClient;

        public OrderController(ICartApiClient cartApiClient, IOrderApiClient orderApiClient, IUserApiClient userApiClient)
        {
            _orderApiClient = orderApiClient;
            _userApiClient = userApiClient;
            _cartApiClient = cartApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderApiClient.GetAllAsync();
            if (TempData["result"] != null)
            {
                if (TempData["result"].ToString() == "true")
                {
                    ViewBag.message = "Deleted order successfully.";
                }
                else ViewBag.message = "Order couldn't remove.";
            }
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Users = await _userApiClient.GetAllAsync();
            if (TempData["result"] != null)
            {
                if (TempData["result"].ToString() == "true")
                {
                    ViewBag.message = "Create category successfully.";
                }
                else ViewBag.message = "category couldn't create.";
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _orderApiClient.CreateAsync(request);
            if (result != null)
            {
                TempData["result"] = "true";
            }
            else
            {
                TempData["result"] = "false";

            }

            return RedirectToAction("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderApiClient.DeleteOrderAsync(id);
            if (result)
            {
                TempData["result"] = "true";
            }
            else
            {
                TempData["result"] = "false";

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var order = await _orderApiClient.GetByIdAsync(id);
            ViewBag.user = await _userApiClient.GetByIdAsync(order.IdUser);
            var orderVm = new OrderUpdateRequest()
            {
                Id = order.Id,
                DateCreated = order.DateCreated,
                DeliveryDate = order.DeliveryDate,
                Total = order.Total,
                UserId = order.IdUser,
                Status = order.Status,
            };
            orderVm.OrderDetails = new List<OrderDetailRequest>();
            if (order.OrderDetails != null)
            {
                foreach (var orderdetails in order.OrderDetails)
                {
                    orderVm.OrderDetails.Add(new OrderDetailRequest()
                    {
                        IdOrder = order.Id,
                        IdProduct = orderdetails.ProductId,
                        Amount = orderdetails.Amount,
                    });

                }
            }
            if (TempData["result"] != null)
            {
                if (TempData["result"].ToString() == "true")
                {
                    ViewBag.message = "Update order successfully.";
                }
                else ViewBag.message = "Order couldn't update.";
            }
            return View(orderVm);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteOrderDetails(int id, int pr)
        {
            var result = await _orderApiClient.DeleteOrderDetails(id, pr);
            return RedirectToAction("Update", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetails(OrderDetailRequest request)
        {
            var res = await _orderApiClient.CreateOrderDetailsAsync(request);
            return RedirectToAction("Update", new { id = request.IdOrder });
        }

        [HttpPost]
        public async Task<IActionResult> Update(OrderUpdateRequest request)
        {
            var result = await _orderApiClient.UpdateOrderAsync(request);
            if (result)
            {
                TempData["result"] = "true";
            }
            else
            {
                TempData["result"] = "false";
            }
            return RedirectToAction("Update", new { id = request.Id });
        }

    }
}
