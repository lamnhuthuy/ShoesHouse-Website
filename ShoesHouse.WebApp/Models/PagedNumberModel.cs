using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.WebApp.Models
{
    public class PagedNumberModel
    {
        public int PageCount { get; set; }
        public int Page { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Keyword { get; set; }
    }
}
