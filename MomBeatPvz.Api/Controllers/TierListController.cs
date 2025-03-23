using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomBeatPvz.Api.Contracts.Championship;
using MomBeatPvz.Api.Contracts.Hero;
using MomBeatPvz.Api.Contracts.TierList;
using MomBeatPvz.Api.Contracts.User;
using MomBeatPvz.Application.Services;
using MomBeatPvz.Application.Services.Interfaces;
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
        private readonly IMapper _mapper;

        public TierListController(ITierListService tierListService, IMapper mapper)
        {
            _tierListService = tierListService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Create(TierListCreateRequestDto dto)
        {
            var userId = long.Parse(User.Claims.FirstOrDefault(i => i.Type == "user_id")!.Value);

            var creator = new User { Id = userId };

            var model = new TierListCreateModel
            {
                Name = dto.Name,
                Description = dto.Description,
                MinPrice = dto.MinPrice,
                MaxPrice = dto.MaxPrice,
                Created = DateTime.UtcNow,
                Championship = new Championship { Id = dto.ChampionshipId, Creator = creator },
                Creator = creator
            };

            await _tierListService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetById(int id)
        {
            var tierList = await _tierListService.GetByIdAsync(id);

            var dto = _mapper.Map<TierListResponseDto>(tierList);

            return Ok(dto);
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Update(TierListUpdateRequestDto dto)
        {
            var userId = long.Parse(User.Claims.FirstOrDefault(i => i.Type == "user_id")!.Value);

            var model = new TierListUpdateModel
            {
                Id = dto.Id,
                AuthorId = userId,
                Name = dto.Name,
                Description = dto.Description,
                MinPrice = dto.MinPrice,
                MaxPrice = dto.MaxPrice
            };

            await _tierListService.UpdateAsync(model);

            return Ok();
        }
    }
}
