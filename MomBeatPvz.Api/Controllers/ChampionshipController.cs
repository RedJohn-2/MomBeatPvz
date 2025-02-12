using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomBeatPvz.Api.Contracts.Championship;
using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Application.Services;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using System.Security.Cryptography.Xml;

namespace MomBeatPvz.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChampionshipController : ControllerBase
    {
        private readonly IChampionshipService _championshipService;
        private readonly IMapper _mapper;

        public ChampionshipController(IChampionshipService championshipService) 
        { 
            _championshipService = championshipService;
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

            return Ok(_mapper.Map<ChampionshipResponse>(championship));
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update(ChampionshipUpdateModel model)
        {
            await _championshipService.UpdateAsync(model);

            return Ok();
        }
    }
}
