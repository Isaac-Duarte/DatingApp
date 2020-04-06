using System;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public interface IHeroRepository
    {
        Task<Hero> AddHero(Hero heroToCreate);
        Task<Hero> ModifyHero(Hero heroToModify);
    }

    public class HeroRepository : IHeroRepository
    {
        private readonly DataContext _context;

        public HeroRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Hero> AddHero(Hero heroToCreate)
        {
            await _context.Heroes.AddAsync(heroToCreate);
            await _context.SaveChangesAsync();

            return heroToCreate;
        }

        public async Task<Hero> ModifyHero(Hero heroToModify)
        {
            var hero = await _context.Heroes.FirstOrDefaultAsync(x => x.Id == heroToModify.Id);

            if (hero == null)
                return null;
            
            hero.FirstName = heroToModify.FirstName;
            hero.LastName = heroToModify.LastName;
            hero.Description = heroToModify.Description;
            hero.Capes = heroToModify.Capes;
            hero.Origin = heroToModify.Origin;

            _context.Heroes.Update(hero);
            await _context.SaveChangesAsync();

            return hero;
        }
    }
}