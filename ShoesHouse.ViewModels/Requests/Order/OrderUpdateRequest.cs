using ShoesHouse.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ViewModels.Requests.Order
{
    public class OrderUpdateRequest
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Status Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public List<OrderDetailRequest> OrderDetails { get; set; }
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }
}
