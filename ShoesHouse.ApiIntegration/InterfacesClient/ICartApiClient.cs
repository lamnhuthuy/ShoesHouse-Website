using ShoesHouse.ViewModels.Requests.Cart;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ApiIntegration.InterfacesClient
{
    public interface ICartApiClient
    {
        Task<int> Create(CartCreateRequest request);
        Task<int> AmountInCart(Guid Id);

        Task<List<CartViewModel>> GetAllByUserIdAsync(Guid id);
    }
}
