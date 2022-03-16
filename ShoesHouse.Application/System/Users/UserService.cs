using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoesHouse.Data.EF;
using ShoesHouse.Data.Entities;
using ShoesHouse.Utilities.Exceptions;
using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.Requests.System.Users;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly ShoesHouseDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration config,
            ShoesHouseDbContext context, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _context = context;
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<ApiResult<string>> AuthenticateAsync(LoginRequest request)
        {
            var username = request.UserName;
            var emailCheck = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.UserName);
            if (emailCheck != null)
            {
                username = emailCheck.UserName;
            }

            var user = await _userManager.FindByEmailAsync(emailCheck.Email);

            if (user == null) return new ApiErrorResult<string>("Tài khoản không tồn tại");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Đăng nhập không đúng");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("Id", user.Id.ToString()),
                new Claim("Role", string.Join(";", roles)),
                new Claim("UserName", user.UserName.ToString()),
                new Claim("Name", user.Name != null ? user.Name.ToString() : ""),
                new Claim("Address", user.Address != null ? user.Address.ToString(): ""),
                new Claim("DoB", user.DoB.ToString()),
                new Claim("PhoneNumber", user.PhoneNumber != null ? user.PhoneNumber.ToString() : ""),
                new Claim("Email", user.Email != null ? user.Email.ToString() : ""),
                 new Claim("Avartar", user.Avatar != null ?  user.Avatar.ToString() : "")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }
        public async Task<List<UserViewModel>> GetAllAsync()
        {
            return await _userManager.Users.Where(m => m.UserName != "admin")
                .Select(x => new UserViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Avatar = x.Avatar,
                    PhoneNumber = x.PhoneNumber,
                    DoB = x.DoB,
                    Email = x.Email,
                }
            ).ToListAsync();

        }

        public async Task<UserViewModel> GetByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                throw new ShoesHouseException($"Cannot find user with Id = {id}");
            }
            var userVm = new UserViewModel()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id,
                Address = user.Address,
                Avatar = user.Avatar,
                DoB = user.DoB,
                Name = user.Name,
            };
            return userVm;
        }
    }
}
