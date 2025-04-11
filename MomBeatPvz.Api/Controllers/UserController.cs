using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Api.Contracts.User;
using MomBeatPvz.Application.Services;
using MomBeatPvz.Application.Services.Interfaces;
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

        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Login(UserAuthRequest request, CancellationToken cancellationToken)
        {
            var jwt = await _userService.AuthAsync(request.Id, request.Username, request.Expired, request.Hash, cancellationToken);
            
            return Ok(jwt);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetById(long id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByIdAsync(id, cancellationToken);

            return Ok(_mapper.Map<UserResponseDto>(user));
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllAsync(cancellationToken);

            return Ok(_mapper.Map<IReadOnlyCollection<UserResponseDto>>(users));
        }
    }
}
