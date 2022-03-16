using ShoesHouse.ViewModels.Requests.Cart;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Application.Interfaces
{
    public interface ICartService
    {
        Task<int> CreatCart(CartCreateRequest request);
        Task<int> AmountInCart(Guid Id);

        Task<List<CartViewModel>> GetByUserIdAsync(Guid id);

        Task<int> DeleteCart(CartCreateRequest request);

    }
}
