using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ViewModels.Requests.Order
{
    public class UpdateStatusRequest
    {
        public int Id { get; set; }
        public int value { get; set; }
    }
}
