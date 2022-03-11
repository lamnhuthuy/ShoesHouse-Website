using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ViewModels.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Size { get; set; }
        public string FileName { get; set; }
        public int Amount { get; set; }
        public decimal OriginalPrice { get; set; }
    }
}
