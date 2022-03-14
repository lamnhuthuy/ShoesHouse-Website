using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.WebApp.Models
{
    public class HomeViewModel
    {
        public PagedResult<ProductViewModel> Products { get; set; }
        public List<ProductViewModel> LatestProduct { get; set; }
    }
}
