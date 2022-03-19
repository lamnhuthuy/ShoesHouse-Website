using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public OrderService(ShoesHouseDbContext context, IMapper mapper, IProductService productService)
        {
            _context = context;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<int> CreateOrderAsync(OrderCreateRequest request)
        {
            var order = new Order()
            {
                UserId = request.UserId,
                Status = request.Status,
                DateCreated = request.DateCreated,
                DeliveryDate = request.DeliveryDate,
                Total = 0000,
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<int> CreateOrderDetailsAsync(OrderDetailRequest request)
        {
            var orderdt = await _context.OrderDetails.Where(x => x.OrderId == request.IdOrder && x.ProductId == request.IdProduct).FirstOrDefaultAsync();
            if (orderdt != null)
            {
                orderdt.Amount = request.Amount;
                return await _context.SaveChangesAsync();
            }
            else
            {
                var orderItem = new OrderDetail()
                {
                    OrderId = request.IdOrder,
                    ProductId = request.IdProduct,
                    Amount = request.Amount,
                };
                await _context.OrderDetails.AddAsync(orderItem);
                await _context.SaveChangesAsync();
                return orderItem.OrderId;
            }
        }

        public async Task<int> DeleteOrderAsync(int orderId)
        {
            var order = await _context.Orders.Where(x => x.Id == orderId).FirstOrDefaultAsync();
            if (order == null)
            {
                throw new ShoesHouseException($"Cannot find category with Id = {order}");
            }
            var orderDetails = await _context.OrderDetails.Where(x => x.OrderId == orderId).ToListAsync();
            foreach (var detail in orderDetails)
            {
                _context.OrderDetails.Remove(detail);
            }
            _context.Orders.Remove(order);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteOrderDetails(int idOrder, int idProduct)
        {
            var orderdt = await _context.OrderDetails.Where(x => x.OrderId == idOrder && x.ProductId == idProduct).FirstOrDefaultAsync();
            if (orderdt == null)
            {
                throw new ShoesHouseException($"Cannot find order with Id = {idOrder}");
            }

            _context.OrderDetails.Remove(orderdt);

            return await _context.SaveChangesAsync();
        }

        public async Task<List<OrderViewModel>> GetAllAsync()
        {
            return await _context.Orders.Include(x => x.User).Include(x => x.OrderDetails).ThenInclude(OrderDetail => OrderDetail.Product).ThenInclude(Product => Product.ProductImages).Select(order => new OrderViewModel()
            {
                Id = order.Id,
                UserName = order.User.Name,
                Status = order.Status,
                DeliveryDate = order.DeliveryDate,
                DateCreated = order.DateCreated,
                OrderDetails = _mapper.Map<List<OrderDetailsViewModel>>(order.OrderDetails),
                Total = order.Total,
            }).ToListAsync();


        }

        public async Task<OrderViewModel> GetByIdAsync(int id)
        {
            var order = await _context.Orders.Include(x => x.User).Include(x => x.OrderDetails)
                .ThenInclude(OrderDetail => OrderDetail.Product)
                .ThenInclude(Product => Product.ProductImages)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            var orderVm = new OrderViewModel()
            {
                IdUser = order.UserId,
                Id = order.Id,
                UserName = order.User.Name,
                Status = order.Status,
                DeliveryDate = order.DeliveryDate,
                DateCreated = order.DateCreated,
                OrderDetails = _mapper.Map<List<OrderDetailsViewModel>>(order.OrderDetails),
                Total = order.Total,
            };
            if (order.OrderDetails != null)
            {
                for (int i = 0; i < order.OrderDetails.Count(); i++)
                {
                    orderVm.OrderDetails[i].Size = order.OrderDetails[i].Product.Size;
                    orderVm.OrderDetails[i].OriginalPrice = order.OrderDetails[i].Product.OriginalPrice;
                }
            }
            return orderVm;

        }

        public async Task<List<OrderViewModel>> GetByUserIdAsync(Guid id)
        {
            var orderlist = await _context.Orders.Include(x => x.User).Include(x => x.OrderDetails)
                  .ThenInclude(OrderDetail => OrderDetail.Product)
                  .ThenInclude(Product => Product.ProductImages)
                  .Where(x => x.UserId == id).ToListAsync();
            List<OrderViewModel> listUserOrder = new List<OrderViewModel>();
            foreach (var order in orderlist)
            {
                var orderVm = new OrderViewModel()
                {
                    IdUser = order.UserId,
                    Id = order.Id,
                    UserName = order.User.Name,
                    Status = order.Status,
                    DeliveryDate = order.DeliveryDate,
                    DateCreated = order.DateCreated,
                    OrderDetails = _mapper.Map<List<OrderDetailsViewModel>>(order.OrderDetails),
                    Total = order.Total,
                };
                if (order.OrderDetails != null)
                {
                    for (int i = 0; i < order.OrderDetails.Count(); i++)
                    {
                        orderVm.OrderDetails[i].Size = order.OrderDetails[i].Product.Size;
                        orderVm.OrderDetails[i].OriginalPrice = order.OrderDetails[i].Product.OriginalPrice;
                    }
                }
                listUserOrder.Add(orderVm);
            }

            return listUserOrder;

        }
        public async Task<int> UpdateOrderAsync(OrderUpdateRequest request)
        {
            var order = await _context.Orders.FindAsync(request.Id);
            if (order == null)
            {
                throw new ShoesHouseException($"Cannot find order with Id = {request.Id}");
            }
            order.Status = request.Status;
            order.DateCreated = request.DateCreated;
            order.DateModified = DateTime.Now;
            order.DeliveryDate = request.DeliveryDate;
            decimal total = 0;

            foreach (var item in request.OrderDetails)
            {
                var product = await _productService.GetByIdAsync(item.IdProduct);
                total = total + item.Amount * product.OriginalPrice;
                await this.CreateOrderDetailsAsync(item);
            }
            order.Total = total;
            return await _context.SaveChangesAsync();
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
