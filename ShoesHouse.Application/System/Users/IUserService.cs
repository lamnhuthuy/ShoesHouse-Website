using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.Requests.System.Users;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Application.System.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> AuthenticateAsync(LoginRequest request);
        Task<List<UserViewModel>> GetAllAsync();

        Task<UserViewModel> GetByIdAsync(Guid Id);

        Task<ApiResult<string>> Register(RegisterRequest request);

        Task<ApiResult<string>> UpdateUser(UserUpdateRequest request);
    }
}
