using ShoesHouse.ViewModels.Requests.Order;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ApiIntegration.InterfacesClient
{
    public interface IOrderApiClient
    {
        Task<List<OrderViewModel>> GetAllAsync();

        Task<bool> UpdateStatusAsync(UpdateStatusRequest request);

        Task<OrderViewModel> CreateAsync(OrderCreateRequest request);

        Task<bool> DeleteOrderAsync(int idOrder);

        Task<bool> UpdateOrderAsync(OrderUpdateRequest request);

        Task<OrderViewModel> GetByIdAsync(int id);

        Task<bool> DeleteOrderDetails(int idOrder, int idProduct);

        Task<bool> CreateOrderDetailsAsync(OrderDetailRequest request);

        Task<List<OrderViewModel>> GetByUserIdAsync(Guid id);
    }
}
