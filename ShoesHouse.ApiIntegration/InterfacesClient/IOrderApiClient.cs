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
    }
}
