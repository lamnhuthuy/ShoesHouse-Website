using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ViewModels.Requests.Product
{
    public class ProductCreateRequest
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal OriginalPrice { get; set; }
        [Required]
        [Range(36, 45, ErrorMessage = "Size from {1} to {2}")]
        public int Size { get; set; }
        [Required]
        [Range(1, 99, ErrorMessage = "Stock from {1} to {2}")]
        public int Stock { get; set; }

        public List<IFormFile> FileUploads { get; set; }
    }

}
