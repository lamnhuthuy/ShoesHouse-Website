using Microsoft.EntityFrameworkCore;
using ShoesHouse.Application.Interfaces;
using ShoesHouse.Data.EF;
using ShoesHouse.Data.Entities;
using ShoesHouse.Data.Enums;
using ShoesHouse.Utilities.Exceptions;
using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.Requests.Order;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly ShoesHouseDbContext _context;

        public OrderService(ShoesHouseDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrderAsync(OrderCreateRequest request)
        {
            var order = new Order()
            {
                UserId = request.UserId,
                Status = request.Status,
                DateCreated = request.DateCreated,
                DeliveryDate = request.DeliveryDate,
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<List<OrderViewModel>> GetAllAsync()
        {
            return await _context.Orders.Include(x => x.User).Select(order => new OrderViewModel()
            {
                Id = order.Id,
                UserName = order.User.Name,
                Status = order.Status,
                DeliveryDate = order.DeliveryDate,
                DateCreated = order.DateCreated,
                Total = order.Total,

            }).ToListAsync();


        }

        public async Task<int> UpdateStatusAsync(UpdateStatusRequest request)
        {
            var order = await _context.Orders.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (order == null)
            {
                throw new ShoesHouseException($"Cannot find order with Id = {request.Id}");
            }
            var enumStatus = Enum.GetValues(typeof(Status));
            foreach (Status item in (Status[])enumStatus)
            {
                if ((int)item == request.value)
                {
                    order.Status = item;
                }
            }
            return await _context.SaveChangesAsync();
        }


    }
}
