using ShoesHouse.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public Status Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        public DateTime? DateCreated { get; set; }
        public decimal Total { get; set; }

    }
}
