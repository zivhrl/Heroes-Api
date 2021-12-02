using Heroes_Api.Contracts;
using Heroes_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Services
{
    public class HeroesSqlRepository : IHeroesRepository
    {
        private HeroesContext _context;
        public HeroesSqlRepository(HeroesContext ctx)
        {
            _context = ctx;
        }

        public bool checkOwnership(Guid heroId, string userId)
        {
            Hero hero = _context.Heroes.Include(hero=>hero.User).First(hero=>hero.Id==heroId);
            return hero.User.Id == userId;
        }

        public PagedResponse<Hero> getHeroes(GetOptions options, string UserId)
        {
            int skip = (options.pageNumber - 1) * options.pageSize;
           
            IQueryable<Hero> heroes = _context.Heroes.Include(hero=>hero.User).OrderBy(hero=>hero.CurrentPower);
            if (UserId != "" && options.filterForTrainer==true)
            {
                heroes = heroes.Where(h => h.User.Id == UserId);
            }
            double maxPages = (double)heroes.Count() / options.pageSize;
            heroes = heroes.Skip(skip).Take(options.pageSize);
            PagedResponse<Hero> response = new PagedResponse<Hero>
            {
                Data = heroes.ToList(),
                MaxPages = (int)Math.Ceiling(maxPages)
            };
            return response;

        }

        public Hero TrainHero(Guid heroId)
        {
            Hero hero = _context.Heroes.Find(heroId);
            if (hero == null)
                return null;
            if (hero.LastTrainingDate.GetValueOrDefault().Date < DateTime.Now.Date)
            {
                hero.LastTrainingDate = DateTime.Now.Date;
                hero.TrainingCounter = 0;
            }
            if (hero.TrainingCounter == 5)
                return null;
            hero.TrainingCounter++;
            Random rnd = new Random();
            double parcent = rnd.Next(0, 1000);
            double num = 1 + (parcent / 10000);
            hero.CurrentPower = hero.CurrentPower * num;
            if (_context.SaveChanges() > 0)
                return hero;
            return null;
        }
    }
}
