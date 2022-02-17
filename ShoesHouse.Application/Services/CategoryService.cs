using Microsoft.EntityFrameworkCore;
using ShoesHouse.Application.Interfaces;
using ShoesHouse.Data.EF;
using ShoesHouse.Data.Entities;
using ShoesHouse.ViewModels.Requests.Category;
using ShoesHouse.ViewModels.Requests.Product;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoesHouse.Utilities.Exceptions;

namespace ShoesHouse.Application.Services
{
    public class CategoryService : ICategoryService
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

        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            return await _context.Categories.Select(category => new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            }).ToListAsync();

        }

        public async Task<CategoryViewModel> GetByIdAsync(int categoryId)
        {
            var category = await _context.Categories.Where(x => x.Id == categoryId).FirstOrDefaultAsync();
            if (category == null)
            {
                throw new ShoesHouseException($"Cannot find category with Id = {categoryId}");
            }
            return new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };


        }

        public Task<int> UpdateAsync(CategoryUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
