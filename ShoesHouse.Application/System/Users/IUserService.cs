using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.Requests.System.Users;
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
    }
}
