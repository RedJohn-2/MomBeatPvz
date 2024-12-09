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
    public class TierListController : ControllerBase
    {
        private readonly ITierListService _tierListService;

        public TierListController(ITierListService tierListService)
        {
            _tierListService = tierListService;
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> Create(TierListCreateModel model)
        {
            await _tierListService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetById(int id)
        {
            var tierList = await _tierListService.GetByIdAsync(id);

            return Ok(tierList);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> Update(TierListUpdateModel model)
        {
            await _tierListService.UpdateAsync(model);

            return Ok();
        }
    }
}
