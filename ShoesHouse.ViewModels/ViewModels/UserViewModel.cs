using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ViewModels.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DoB { get; set; }

    }
}
