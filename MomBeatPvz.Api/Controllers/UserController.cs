using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Infrastructure.Auth;

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
        [Authorize]
        public async Task<ActionResult> Login()
        {
            var userId = long.Parse(User.Claims.First(c => c.Type == "user_id").Value);

            var username = User.Claims.First(c => c.Type == "username").Value;

            await _userService.AuthAsync(new User { Id = userId, Name = username});

            return Ok();
        }
    }
}
