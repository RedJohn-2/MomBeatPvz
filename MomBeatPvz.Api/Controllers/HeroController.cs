using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public HeroController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Create(HeroCreateModel model)
        {
            await _heroService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetById(int id)
        {
            var hero = await _heroService.GetByIdAsync(id);

            return Ok(hero);
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update(HeroUpdateModel model)
        {
            await _heroService.UpdateAsync(model);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll()
        {
            var heros = await _heroService.GetAllAsync();

            return Ok(heros);
        }
    }
}
