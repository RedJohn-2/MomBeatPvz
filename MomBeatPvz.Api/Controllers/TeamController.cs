using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomBeatPvz.Api.Contracts.Championship;
using MomBeatPvz.Api.Contracts.Team;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Application.Services;
using MomBeatPvz.Core.Model;

namespace MomBeatPvz.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public TeamController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;   
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> Create(TeamCreateRequestDto dto)
        {
            var userId = long.Parse(User.Claims.FirstOrDefault(i => i.Type == "user_id")!.Value);

            var model = new TeamCreateModel
            {
                Name = dto.Name,
                Author = new User { Id = userId },
                Heroes = dto.HeroIds.Select(x => new Hero { Id = x }).ToList(),
                Championship = new Championship { Id = dto.ChampionshipId }
            };

            await _teamService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetById(long id)
        {
            var team = await _teamService.GetByIdAsync(id);

            return Ok(_mapper.Map<TeamResponseDto>(team));
        }

        [HttpPut("[action]")]
        [Authorize]
        public async Task<ActionResult> Update(TeamUpdateRequestDto dto)
        {
            var userId = long.Parse(User.Claims.FirstOrDefault(i => i.Type == "user_id")!.Value);

            var model = new TeamUpdateModel
            {
                Id = dto.Id,
                AuthorId = userId,
                Name = dto.Name,
                Heroes = dto.HeroIds is not null ? dto.HeroIds.Select(x => new Hero { Id = x }).ToList() : null,
            };

            await _teamService.UpdateAsync(model);

            return Ok();
        }
    }
}
