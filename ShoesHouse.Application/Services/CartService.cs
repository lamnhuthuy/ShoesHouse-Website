using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoesHouse.Application.Interfaces;
using ShoesHouse.Application.System.Users;
using ShoesHouse.Data.EF;
using ShoesHouse.Data.Entities;
using ShoesHouse.Utilities.Exceptions;
using ShoesHouse.ViewModels.Requests.Cart;
using ShoesHouse.ViewModels.Requests.Order;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ShoesHouseDbContext _context;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public CartService(ShoesHouseDbContext context, IMapper mapper, IOrderService orderService)
        {
            _context = context;
            _mapper = mapper;
            _orderService = orderService;
        }

        public async Task<int> AmountInCart(Guid Id)
        {
            var list = await _context.Carts.Where(x => x.UserId == Id).ToListAsync();
            return list.Count();
        }

        public async Task<int> CheckOut(Guid userId)
        {
            var carts = await _context.Carts.Include(x => x.Product).Where(x => x.UserId == userId).ToListAsync();
            decimal total = 0;
            if (carts.Count() > 0)
            {
                foreach (var item in carts)
                {
                    total = total + item.Amount * item.Product.OriginalPrice;
                }
                var order = new Order()
                {
                    UserId = userId,
                    Status = Data.Enums.Status.Confirmed,
                    DateCreated = DateTime.Now,
                    DeliveryDate = DateTime.Now,
                    Total = total,
                };
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                foreach (var item in carts)
                {
                    var orderdt = new OrderDetail()
                    {
                        OrderId = order.Id,
                        ProductId = item.ProductId,
                        Amount = item.Amount,

                    };
                    await _context.OrderDetails.AddAsync(orderdt);
                    _context.Carts.Remove(item);
                    await _context.SaveChangesAsync();
                }
                return order.Id;
            }
            return 0;
        }

        public async Task<int> CreatCart(CartCreateRequest request)
        {
            var cart = await _context.Carts.Where(x => x.UserId == request.UserId && x.ProductId == request.ProductId).FirstOrDefaultAsync();
            if (cart != null)
            {
                cart.Amount++;

            }
            else
            {
                var cartVm = new Cart()
                {
                    UserId = request.UserId,
                    ProductId = request.ProductId,
                    Amount = 1,
                };
                await _context.Carts.AddAsync(cartVm);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCart(CartCreateRequest request)
        {
            var cart = await _context.Carts.Where(x => x.ProductId == request.ProductId && x.UserId == request.UserId).FirstOrDefaultAsync();
            if (cart == null)
            {
                throw new ShoesHouseException($"Cannot find order with UserId = {request.UserId}");
            }
            _context.Carts.Remove(cart);

            return await _context.SaveChangesAsync();
        }

        public Task<List<CartViewModel>> GetByUserIdAsync(Guid id)
        {
            var data = _context.Carts.Include(x => x.Product).ThenInclude(Product => Product.ProductImages).Where(x => x.UserId == id).Select(cart => new CartViewModel()
            {
                FileName = cart.Product.ProductImages.FirstOrDefault().FileName,
                ProductName = cart.Product.Name,
                ProductId = cart.ProductId,
                Amount = cart.Amount,
                OriginalPrice = cart.Product.OriginalPrice,
                Size = cart.Product.Size,

            }).ToListAsync();
            return data;
        }

        public async Task<int> UpdateCartAsync(CartUpdateRequest request)
        {

            var cart = await _context.Carts.Where(x => x.ProductId == request.IdProduct && x.UserId == request.UserId).FirstOrDefaultAsync();
            if (cart == null)
            {
                throw new ShoesHouseException($"Cannot find category with Id = {request.UserId}");
            }
            cart.Amount = request.Amount;

            return await _context.SaveChangesAsync();
        }
    }
}
