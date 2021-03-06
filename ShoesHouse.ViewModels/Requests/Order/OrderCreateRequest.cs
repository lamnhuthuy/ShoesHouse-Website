using ShoesHouse.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ViewModels.Requests.Order
{
    public class OrderCreateRequest
    {
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "UserName")]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public Status Status { get; set; }

        [Required(ErrorMessage = "Delivery date is required")]
        [Display(Name = "Delivery Date")]
        public DateTime? DeliveryDate { get; set; }
        [Required(ErrorMessage = "Order date is required")]
        [Display(Name = "Order Date")]
        public DateTime? DateCreated { get; set; }

    }
}
