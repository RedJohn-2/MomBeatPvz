using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomBeatPvz.Api.Contracts.Championship;
using MomBeatPvz.Api.Contracts.Match;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Application.Services;
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
        public async Task<ActionResult> Create(MatchCreateRequestDto dto)
        {
            var model = new MatchCreateModel
            {
                Championship = new Championship { Id = dto.ChampionshipId }
            };

            await _matchService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetById(long id)
        {
            var match = await _matchService.GetByIdAsync(id);

            return Ok(_mapper.Map<MatchResponseDto>(match));
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update(MatchUpdateRequestDto dto)
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

            await _matchService.UpdateAsync(model);

            return Ok();
        }
    }
}
