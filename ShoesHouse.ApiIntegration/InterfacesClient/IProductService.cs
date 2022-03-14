using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.Requests.Product;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ApiIntegration.InterfacesClient
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllAsync();
        Task<bool> CreateProductAsync(ProductCreateRequest request);

        Task<bool> DeleteProductAsync(int productId);

        Task<ProductViewModel> GetByIdAsync(int productId);
        Task<bool> UpdateProductAsync(ProductUpdateRequest request);

        Task<List<ProductViewModel>> GetLatestProductAsync();

        Task<PagedResult<ProductViewModel>> GetAllPagingAsync(GetProductPagingRequest request);
    }
}
