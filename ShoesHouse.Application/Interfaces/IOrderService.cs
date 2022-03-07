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
    }
}
