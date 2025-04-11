using Microsoft.Extensions.Caching.Distributed;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Application.Services.Abstract;
using MomBeatPvz.Application.Services.Interfaces;
using MomBeatPvz.Core.Exceptions;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.Store;

namespace MomBeatPvz.Application.Services
{
    public class HeroService :
        BaseService<Hero, HeroCreateModel, HeroUpdateModel, int, IHeroStore>, 
        IHeroService
    {
        protected override string ModelName => nameof(Hero);

        public HeroService(IHeroStore heroStore, ICacheProvider cache) : base(heroStore, cache) { }

        public void CheckDuplicates(List<Hero> heroes)
        {
            var uniqueHeroes = heroes.Select(x => x.Id).Distinct().Count();

            if (heroes.Count != uniqueHeroes)
            {
                throw new DuplicateException("Дубликаты героев!");
            }
        }
    }
}
