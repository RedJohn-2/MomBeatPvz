using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelCreate;
using MomBeatPvz.Core.ModelUpdate;
using MomBeatPvz.Core.Store;
using MomBeatPvz.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Repositories
{
    public class HeroRepository : IHeroStore
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;

        public HeroRepository(ApplicationContext db, IMapper mapper)
        {  
            _db = db;
            _mapper = mapper;
        }

        public async Task Create(HeroCreateModel hero)
        {
            var heroEntity = _mapper.Map<HeroEntity>(hero);

            await _db.AddAsync(heroEntity);

            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _db.Heroes
                .Where(h => h.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<bool> Exist(int id)
        {
            return await _db.Heroes
                .Where(h => h.Id == id)
                .AnyAsync();
        }

        public async Task<IReadOnlyList<Hero>> GetAll()
        {
            var entities = await _db.Heroes.ToListAsync();

            return _mapper.Map<IReadOnlyList<Hero>>(entities);
        }

        public async Task<Hero> GetById(int id)
        {
            var existedHero = await _db.Heroes
                .FirstOrDefaultAsync(h => h.Id == id)
                ?? throw new Exception();

            return _mapper.Map<Hero>(existedHero);
        }

        public async Task Update(HeroUpdateModel hero)
        {
            var existedHero = await _db.Heroes
                .FirstOrDefaultAsync(h => h.Id == hero.Id)
                ?? throw new Exception();

            _mapper.Map(hero, existedHero);

            await _db.SaveChangesAsync();
        }
    }
}
