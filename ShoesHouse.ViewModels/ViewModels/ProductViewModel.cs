using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ViewModels.ViewModels
{
    public class ProductViewModel
    {
        public List<ProductImageViewModel> ProductImages { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Size { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public DateTime? DateModified { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
