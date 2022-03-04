﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ViewModels.Requests.Product
{
    public class ProductUpdateRequest
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Size { get; set; }
        public int Stock { get; set; }

        public List<IFormFile> FileUploads { get; set; }
    }
}
