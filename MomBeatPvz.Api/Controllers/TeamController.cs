using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomBeatPvz.Api.Contracts.Championship;
using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Api.Contracts.Team;
using MomBeatPvz.Application.Services;
using MomBeatPvz.Application.Services.Interfaces;
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
        public async Task<ActionResult> Create(TeamCreateRequestDto dto, CancellationToken cancellationToken)
        {
            var userId = long.Parse(User.Claims.FirstOrDefault(i => i.Type == "user_id")!.Value);

            var model = new TeamCreateModel
            {
                Name = dto.Name,
                Author = new User { Id = userId },
                Heroes = dto.HeroIds.Select(x => new Hero { Id = x }).ToList(),
                Championship = new Championship { Id = dto.ChampionshipId }
            };

            await _teamService.CreateAsync(model, cancellationToken);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetById(long id, CancellationToken cancellationToken)
        {
            var team = await _teamService.GetByIdAsync(id, cancellationToken);

            return Ok(_mapper.Map<TeamResponseDto>(team));
        }
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            var teams = await _teamService.GetAllAsync(cancellationToken);

            return Ok(_mapper.Map<IReadOnlyCollection<TeamResponseDto>>(teams));
        }


        [HttpPut("[action]")]
        [Authorize]
        public async Task<ActionResult> Update(TeamUpdateRequestDto dto, CancellationToken cancellationToken)
        {
            var userId = long.Parse(User.Claims.FirstOrDefault(i => i.Type == "user_id")!.Value);

            var model = new TeamUpdateModel
            {
                Id = dto.Id,
                AuthorId = userId,
                Name = dto.Name,
                Heroes = dto.HeroIds is not null ? dto.HeroIds.Select(x => new Hero { Id = x }).ToList() : null,
            };

            await _teamService.UpdateAsync(model, cancellationToken);

            return Ok();
        }
    }
}
