using ShoesHouse.ViewModels.Requests.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<int> CreateAsync(CategoryCreateRequest request);

        Task<int> UpdateAsync(CategoryUpdateRequest request);

        Task<int> DeleteAsync(int categoryId);


    }
}
