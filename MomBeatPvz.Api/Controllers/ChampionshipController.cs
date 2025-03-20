using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomBeatPvz.Api.Contracts.Championship;
using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Application.Services;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using System.Security.Cryptography.Xml;

namespace MomBeatPvz.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChampionshipController : ControllerBase
    {
        private readonly IChampionshipService _championshipService;
        private readonly IMapper _mapper;

        public ChampionshipController(IChampionshipService championshipService, IMapper mapper) 
        { 
            _championshipService = championshipService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Create(ChampionshipCreateRequestDto dto)
        {
            var userId = long.Parse(User.Claims.FirstOrDefault(i => i.Type == "user_id")!.Value);

            var model = new ChampionshipCreateModel
            {
                Name = dto.Name,
                Description = dto.Description,
                TeamPrice = dto.TeamPrice,
                Format = dto.Format,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Heroes = dto.HeroIds.Select(x => new Hero { Id = x }).ToList(),
                Creator = new User { Id = userId }
            };

            await _championshipService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetById(long id)
        {
            var championship = await _championshipService.GetByIdAsync(id);

            return Ok(_mapper.Map<ChampionshipResponseDto>(championship));
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update(ChampionshipUpdateRequestDto dto)
        {
            var userId = long.Parse(User.Claims.FirstOrDefault(i => i.Type == "user_id")!.Value);

            var model = new ChampionshipUpdateModel
            {
                Id = dto.Id,
                AuthorId = userId,
                Name = dto.Name,
                Description = dto.Description,
                TeamPrice = dto.TeamPrice,
                Stage = dto.Stage,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Teams = dto.TeamIds is not null ? dto.TeamIds.Select(x => new Team { Id = x}).ToList() : null,
                Matches = dto.MatchIds is not null ? dto.MatchIds.Select(x => new Match { Id = x }).ToList() : null,
                Heroes = dto.HeroIds is not null ? dto.HeroIds.Select(x => new Hero { Id = x }).ToList() : null,
            };

            await _championshipService.UpdateAsync(model);

            return Ok();
        }
    }
}
