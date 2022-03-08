using ShoesHouse.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ViewModels.Requests.Order
{
    public class OrderCreateRequest
    {
        public Guid UserId { get; set; }
        public Status Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? DateCreated { get; set; }

    }
}
