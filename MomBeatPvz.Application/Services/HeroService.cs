using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.Store;

namespace MomBeatPvz.Application.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroStore _heroStore;

        public HeroService(IHeroStore heroStore)
        {
            _heroStore = heroStore;
        }

        public async Task CreateAsync(HeroCreateModel model)
        {
            await _heroStore.Create(model);
        }

        public async Task UpdateAsync(HeroUpdateModel model)
        {
            await _heroStore.Update(model);
        }

        public async Task<Hero> GetByIdAsync(int id)
        {
            return await _heroStore.GetById(id);
        }

        public async Task<IReadOnlyList<Hero>> GetAllAsync()
        {
            return await _heroStore.GetAll();
        }
    }
}
