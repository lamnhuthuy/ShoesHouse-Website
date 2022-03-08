using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.Requests.Order;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Application.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderViewModel>> GetAllAsync();
        Task<int> UpdateStatusAsync(UpdateStatusRequest request);
        Task<int> CreateOrderAsync(OrderCreateRequest request);

        Task<OrderViewModel> GetByIdAsync(int id);
    }
}
