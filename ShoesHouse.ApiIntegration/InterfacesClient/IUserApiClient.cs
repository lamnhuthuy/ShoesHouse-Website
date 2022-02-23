using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.Requests.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ApiIntegration.InterfacesClient
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
