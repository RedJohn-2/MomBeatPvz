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

namespace MomBeatPvz.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _heroService;
        private readonly IMapper _mapper;

        public HeroController(IHeroService heroService, IMapper mapper)
        {
            _heroService = heroService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Create(HeroCreateRequestDto dto)
        {
            var model = new HeroCreateModel
            {
                Name = dto.Name,
                Url = dto.Url
            };

            await _heroService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetById(int id)
        {
            var hero = await _heroService.GetByIdAsync(id);

            return Ok(_mapper.Map<HeroResponseDto>(hero));
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update(HeroUpdateRequestDto dto)
        {
            var model = new HeroUpdateModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Url = dto.Url
            };

            await _heroService.UpdateAsync(model);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll()
        {
            var heros = await _heroService.GetAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<HeroResponseDto>>(heros));
        }
    }
}
