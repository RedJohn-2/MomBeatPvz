using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomBeatPvz.Api.Contracts;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Infrastructure.Auth;
using System.Security.Claims;

namespace MomBeatPvz.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Login(UserAuthRequest request)
        {
            await _userService.AuthAsync(request.TelegramId, request.Name, Guid.Parse(request.Secret));
            
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Create()
        {
            var secret = await _userService.CreateAsync();

            return Ok(secret);
        }
    }
}
