using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ViewModels.Requests.Cart
{
    public class CartCreateRequest
    {
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
    }
}
