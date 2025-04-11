using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomBeatPvz.Api.Contracts.Championship;
using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Application.Services;
using MomBeatPvz.Application.Services.Interfaces;
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
        public async Task<ActionResult> Create(HeroCreateRequestDto dto, CancellationToken cancellationToken)
        {
            var model = new HeroCreateModel
            {
                Name = dto.Name,
                Url = dto.Url
            };

            await _heroService.CreateAsync(model, cancellationToken);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var hero = await _heroService.GetByIdAsync(id, cancellationToken);

            return Ok(_mapper.Map<HeroResponseDto>(hero));
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update(HeroUpdateRequestDto dto, CancellationToken cancellationToken)
        {
            var model = new HeroUpdateModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Url = dto.Url
            };

            await _heroService.UpdateAsync(model, cancellationToken);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            var heroes = await _heroService.GetAllAsync(cancellationToken);

            return Ok(_mapper.Map<IReadOnlyCollection<HeroResponseDto>>(heroes));
        }
    }
}
