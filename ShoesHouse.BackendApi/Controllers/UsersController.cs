using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesHouse.Application.System.Users;
using ShoesHouse.ViewModels.Requests.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.AuthenticateAsync(request);

            if (string.IsNullOrEmpty(resultToken.ResultObj))
            {
                return BadRequest(resultToken);
            }
            return Ok(resultToken);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userName = await _userService.GetAllAsync();
            return Ok(userName);
        }
        [HttpGet("{IdUser}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid IdUser)
        {
            try
            {
                var category = await _userService.GetByIdAsync(IdUser);
                if (category == null)
                {
                    return NotFound($"Cannot find a user with Id: {IdUser}");
                }

                return Ok(category);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
