using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ViewModels.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserViewModel UserViewModel { get; set; }
        public List<OrderViewModel> OrderViewModel { get; set; }

    }
}
