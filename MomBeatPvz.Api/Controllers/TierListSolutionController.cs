using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomBeatPvz.Api.Contracts.Championship;
using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Api.Contracts.TierListSolution;
using MomBeatPvz.Application.Services;
using MomBeatPvz.Application.Services.Interfaces;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;

namespace MomBeatPvz.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TierListSolutionController : ControllerBase
    {
        private readonly ITierListSolutionService _tierListSolutionService;
        private readonly IMapper _mapper;

        public TierListSolutionController(ITierListSolutionService tierListSolutionService, IMapper mapper)
        {
            _tierListSolutionService = tierListSolutionService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> Create(TierListSolutionCreateRequestDto dto, CancellationToken cancellationToken)
        {
            var userId = long.Parse(User.Claims.FirstOrDefault(i => i.Type == "user_id")!.Value);

            var model = new TierListSolutionCreateModel
            {
                TierList = new TierList { Id = dto.TierListId },
                Owner = new User { Id = userId },
                HeroPrices = dto.HeroPrices.Select(x => new HeroPrice
                {
                    Hero = new Hero { Id = x.Key },
                    Value = x.Value
                }).ToList()
            };

            await _tierListSolutionService.CreateAsync(model, cancellationToken);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var solution = await _tierListSolutionService.GetByIdAsync(id, cancellationToken);

            return Ok(_mapper.Map<TierListSolutionResponseDto>(solution));
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> Update(TierListSolutionUpdateRequestDto dto, CancellationToken cancellationToken)
        {
            var userId = long.Parse(User.Claims.FirstOrDefault(i => i.Type == "user_id")!.Value);

            var model = new TierListSolutionUpdateModel
            {
                Id = dto.Id,
                AuthorId = userId,
                HeroPrices = dto.HeroPrices is not null ? dto.HeroPrices.Select(x => new HeroPrice
                {
                    Hero = new Hero { Id = x.Key },
                    Value = x.Value
                }).ToList() : null,
            };

            await _tierListSolutionService.UpdateAsync(model, cancellationToken);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            var solutions = await _tierListSolutionService.GetAllAsync(cancellationToken);

            return Ok(_mapper.Map<IReadOnlyCollection<TierListSolutionResponseDto>>(solutions));
        }

        /*[HttpDelete("[action]")]
        public async Task<ActionResult> Delete(long id)
        {
            await _tierListSolutionService.DeleteAsync(id);

            return Ok();
        }*/
    }
}
