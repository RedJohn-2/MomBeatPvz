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
            var jwt = await _userService.AuthAsync(request.Id, request.Username, request.Expired, request.Hash);
            
            return Ok(jwt);
        }
    }
}
