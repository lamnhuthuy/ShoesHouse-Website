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
        private readonly IProductService _productService;
        public CategoryService(ShoesHouseDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
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

        public async Task<int> DeleteAsync(int categoryId)
        {
            var category = await _context.Categories.Where(x => x.Id == categoryId).FirstOrDefaultAsync();
            if (category == null)
            {
                throw new ShoesHouseException($"Cannot find category with Id = {categoryId}");
            }
            var productList = await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
            foreach (var product in productList)
            {
                await _productService.DeleteAsync(product.Id);
            }
            _context.Categories.Remove(category);

            return await _context.SaveChangesAsync();
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

        public async Task<int> UpdateAsync(CategoryUpdateRequest request)
        {
            var category = await _context.Categories.FindAsync(request.Id);
            if (category == null)
            {
                throw new ShoesHouseException($"Cannot find category with Id = {request.Id}");
            }
            category.Name = request.Name;
            category.Description = request.Description;

            return await _context.SaveChangesAsync();

        }
    }
}
