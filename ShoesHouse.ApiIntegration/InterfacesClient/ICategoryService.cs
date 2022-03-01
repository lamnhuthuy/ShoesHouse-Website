using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.Requests.Category;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ApiIntegration.InterfacesClient
{
    public interface ICategoryService
    {
        public Task<List<CategoryViewModel>> GetAllAsync();
        public Task<bool> DeleteCategoryAsync(int id);
        public Task<CategoryViewModel> GetByIdAsync(int id);
        public Task<bool> UpdateCategoryAsync(CategoryUpdateRequest request);
        public Task<CategoryViewModel> CreateCategoryAsync(CategoryCreateRequest request);
    }
}
