using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoesHouse.Application.Interfaces;
using ShoesHouse.Data.EF;
using ShoesHouse.Data.Entities;
using ShoesHouse.Utilities.Exceptions;
using ShoesHouse.ViewModels.Common;
using ShoesHouse.ViewModels.Requests.System.Users;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
        private readonly IStorageService _storageService;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration config,
            ShoesHouseDbContext context, RoleManager<AppRole> roleManager, IMapper mapper, IStorageService storageService)
        {
            _context = context;
            _config = config;
            _userManager = userManager;
            _storageService = storageService;
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
            else
            {
                return new ApiErrorResult<string>("Tài khoản không tồn tại");
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

        public async Task<ApiResult<string>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiErrorResult<string>("Tài khoản đã tồn tại");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<string>("Emai đã tồn tại");
            }

            user = new AppUser()
            {

                Email = request.Email,
                Address = request.Address,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                Avatar = "default-avatar.png",
                Name = request.UserName,

            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<string>("Thanh cong");
            }
            return new ApiErrorResult<string>("Đăng ký không thành công");
        }

        public async Task<ApiResult<string>> UpdateUser(UserUpdateRequest request)
        {
            var user = await _userManager.Users.AnyAsync(x => x.UserName == request.UserName && x.Id != request.Id);
            if (user == true)
            {
                return new ApiErrorResult<string>("Tài khoản đã tồn tại");
            }
            var mail = await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != request.Id);
            if (mail == true)
            {
                return new ApiErrorResult<string>("Emai đã tồn tại");
            }
            var usr = await _userManager.FindByIdAsync(request.Id.ToString());
            usr.Name = request.UserName;
            usr.Address = request.Address;
            usr.Email = request.Email;
            usr.PhoneNumber = request.PhoneNumber;
            if (request.fileName != null && usr.Avatar != "default-avatar.png")
            {
                _storageService.DeleteFileAsync(usr.Avatar);
                usr.Avatar = await this.SaveFile(request.fileName);
            }
            else if (request.fileName != null && usr.Avatar == "default-avatar.png")
            {
                usr.Avatar = await this.SaveFile(request.fileName);
            }
            var result = await _userManager.UpdateAsync(usr);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<string>("Cap nhat thanh cong");
            }
            return new ApiErrorResult<string>("Cập nhật không thành công");
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}

