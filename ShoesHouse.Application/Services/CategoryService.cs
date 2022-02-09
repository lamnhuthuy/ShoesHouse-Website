using ShoesHouse.Application.Interfaces;
using ShoesHouse.Data.EF;
using ShoesHouse.Data.Entities;
using ShoesHouse.ViewModels.Requests.Category;
using ShoesHouse.ViewModels.Requests.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Application.Services
{
    class CategoryService : ICategoryService
    {
        private readonly ShoesHouseDbContext _context;
        public CategoryService(ShoesHouseDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(CategoryCreateRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return 0;
            }
            var category = new Category()
            {
                Name = request.Name,
                Description = request.Description
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.Id;

        }

        public Task<int> DeleteAsync(int ProductId)
        {
            throw new NotImplementedException();
        }


        public Task<int> UpdateAsync(CategoryUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
