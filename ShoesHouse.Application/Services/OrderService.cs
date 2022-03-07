using Microsoft.EntityFrameworkCore;
using ShoesHouse.Application.Interfaces;
using ShoesHouse.Data.EF;
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
    }
}
