using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.Requests.System.Users;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ApiIntegration.InterfacesClient
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<List<UserViewModel>> GetAllAsync();

        Task<UserViewModel> GetByIdAsync(Guid Id);
    }
}
