using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.Requests.Product;
using ShoesHouse.ViewModels.ViewModels;

namespace ShoesHouse.Application.Interfaces
{
    public interface IProductService
    {
        Task<int> CreateAsync(ProductCreateRequest request);

        Task<int> UpdateAsync(ProductUpdateRequest request);

        Task<int> DeleteAsync(int ProductId);
        Task<List<ProductViewModel>> GetAllAsync();

        Task<ProductViewModel> GetByIdAsync(int productId);

        Task<PagedResult<ProductViewModel>> GetAllPagingAsync(GetProductPagingRequest request);

        Task<List<ProductViewModel>> GetLatestProduct();

        Task<int> AddComment(int idproduct, string comment, Guid user);

        Task<List<ProductViewModel>> GetBackToSchool();
        Task<List<ProductViewModel>> GetBestChoice();
    }
}
