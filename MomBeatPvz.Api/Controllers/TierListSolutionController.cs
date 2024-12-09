using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;

namespace MomBeatPvz.Api.Controllers
{
    public class TierListSolutionController : ControllerBase
    {
        private readonly ITierListSolutionService _tierListSolutionService;

        public TierListSolutionController(ITierListSolutionService tierListSolutionService)
        {
            _tierListSolutionService = tierListSolutionService;
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> Create(TierListSolutionCreateModel model)
        {
            await _tierListSolutionService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetById(int id)
        {
            var solution = await _tierListSolutionService.GetByIdAsync(id);

            return Ok(solution);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> Update(TierListSolutionUpdateModel model)
        {
            await _tierListSolutionService.UpdateAsync(model);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll()
        {
            var solutions = await _tierListSolutionService.GetAllAsync();

            return Ok(solutions);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete(long id)
        {
            await _tierListSolutionService.DeleteAsync(id);

            return Ok();
        }
    }
}
