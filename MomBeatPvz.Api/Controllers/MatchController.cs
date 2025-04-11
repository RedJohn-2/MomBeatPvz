using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomBeatPvz.Api.Contracts.Championship;
using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Api.Contracts.Match;
using MomBeatPvz.Application.Services;
using MomBeatPvz.Application.Services.Interfaces;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate;

namespace MomBeatPvz.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMapper _mapper;

        public MatchController(IMatchService matchService, IMapper mapper)
        {
            _matchService = matchService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Create(MatchCreateRequestDto dto, CancellationToken cancellationToken)
        {
            var model = new MatchCreateModel
            {
                Championship = new Championship { Id = dto.ChampionshipId }
            };

            await _matchService.CreateAsync(model, cancellationToken);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetById(long id, CancellationToken cancellationToken)
        {
            var match = await _matchService.GetByIdAsync(id, cancellationToken);

            return Ok(_mapper.Map<MatchResponseDto>(match));
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            var matches = await _matchService.GetAllAsync(cancellationToken);

            return Ok(_mapper.Map<IReadOnlyCollection<MatchResponseDto>>(matches));
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update(MatchUpdateRequestDto dto, CancellationToken cancellationToken)
        {
            var model = new MatchUpdateModel
            {
                Id = dto.Id,
                IsCompleted = dto.IsCompleted,
                Results = dto.Results is not null ? dto.Results.Select(x => new MatchResult
                {
                    Match = new Match { Id = dto.Id },
                    Team = new Team { Id = x.Key },
                    Score = x.Value
                })
                .ToList() : null
            };

            await _matchService.UpdateAsync(model, cancellationToken);

            return Ok();
        }
    }
}
