using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoesHouse.ViewModels.Requests.Product;

namespace ShoesHouse.Application.Interfaces
{
    public interface IProductService
    {
        Task<int> CreateAsync(ProductCreateRequest request);

        Task<int> UpdateAsync(ProductUpdateRequest request);

        Task<int> DeleteAsync(int ProductId);

    }
}
