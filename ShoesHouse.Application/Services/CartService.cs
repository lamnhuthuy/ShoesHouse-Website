using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoesHouse.Application.Interfaces;
using ShoesHouse.Data.EF;
using ShoesHouse.Data.Entities;
using ShoesHouse.Utilities.Exceptions;
using ShoesHouse.ViewModels.Requests.Cart;
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


        public CartService(ShoesHouseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AmountInCart(Guid Id)
        {
            var list = await _context.Carts.Where(x => x.UserId == Id).ToListAsync();
            return list.Count();
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
    }
}
