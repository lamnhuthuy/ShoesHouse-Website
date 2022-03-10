using Microsoft.AspNetCore.Mvc;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoesHouse.AdminApp.Controllers.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<Claim> claims)
        {

            return View();
        }
    }
}
