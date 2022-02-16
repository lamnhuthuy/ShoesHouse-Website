using ShoesHouse.Application.Interfaces;
using ShoesHouse.ViewModels.Requests.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Application.Services
{
    public class ProductService : IProductService
    {


        public Task<int> CreateAsync(ProductCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
