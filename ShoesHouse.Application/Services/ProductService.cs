using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShoesHouse.Application.Interfaces;
using ShoesHouse.Data.EF;
using ShoesHouse.Data.Entities;
using ShoesHouse.Utilities.Exceptions;
using ShoesHouse.ViewModels.Requests.Product;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ShoesHouseDbContext _context;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;


        public ProductService(ShoesHouseDbContext context, IMapper mapper, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<int> CreateAsync(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                Size = request.Size,
                Stock = request.Stock,
                OriginalPrice = request.OriginalPrice,
                Price = request.Price,
            };
            product.DateCreated = DateTime.Now;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            if (request.FileUploads != null)
            {
                foreach (var file in request.FileUploads)
                {

                    var productImg = new ProductImage()
                    {
                        ProductId = product.Id,
                        FileName = await this.SaveFile(file),
                        Caption = "Product image",
                    };
                    await _context.ProductImages.AddAsync(productImg);
                    await _context.SaveChangesAsync();
                }
            }
            return product.Id;

        }

        public async Task<int> DeleteAsync(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null) throw new ShoesHouseException($"Cannot find a product: {ProductId}");

            var images = await _context.ProductImages.Where(i => i.ProductId == ProductId).ToListAsync();
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.FileName);
            }

            _context.Products.Remove(product);

            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {

            return await _context.Products.Include(x => x.ProductImages).Include(x => x.Category).Select(product => new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                OriginalPrice = product.OriginalPrice,
                Size = product.Size,
                CategoryName = product.Category.Name,
                ProductImages = _mapper.Map<List<ProductImageViewModel>>(product.ProductImages),
                DateModified = product.DateModified,
                DateCreated = product.DateCreated,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Stock = product.Stock
            }).ToListAsync();

        }

        public async Task<ProductViewModel> GetByIdAsync(int productId)
        {
            var product = await _context.Products.Include(x => x.ProductImages).Include(x => x.Comments).ThenInclude(Comment => Comment.User).Where(product => product.Id == productId).FirstOrDefaultAsync();
            if (product == null)
            {
                throw new ShoesHouseException($"Cannot find category with Id = {productId}");
            }
            var productVm = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Size = product.Size,
                Description = product.Description,
                ProductImages = _mapper.Map<List<ProductImageViewModel>>(product.ProductImages),
                Comments = _mapper.Map<List<CommentViewModel>>(product.Comments),
            };
            return productVm;

        }

        public Task<int> UpdateAsync(ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
