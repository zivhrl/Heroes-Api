using AutoMapper;
using Heroes_Api.Contracts;
using Heroes_Api.Dtos;
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
        private IMapper _mapper;
        public HeroesSqlRepository(HeroesContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }

        public bool checkOwnership(Guid heroId, string userId)
        {
            Hero hero = _context.Heroes.Include(hero=>hero.User).First(hero=>hero.Id==heroId);
            return hero.User.Id == userId;
        }

        public PagedResponse<HeroDto> getHeroes(GetOptions options, string userId)
        {
            int skip = (options.pageNumber - 1) * options.pageSize;
           
            IQueryable<Hero> heroes = _context.Heroes.Include(hero=>hero.User).OrderBy(hero=>hero.CurrentPower);
            if (options.filterForTrainer==true)
            {
                heroes = heroes.Where(h => h.User.Id == userId);
            }
            double maxPages = (double)heroes.Count() / options.pageSize;
            heroes = heroes.Skip(skip).Take(options.pageSize);
            List<HeroDto> heroesDtos = new List<HeroDto>();
            foreach (Hero hero in heroes)
            {
                hero.setTrainingCounter();
                HeroDto dto = _mapper.Map<HeroDto>(hero);
                dto.CanTrain = hero.User.Id == userId;
                heroesDtos.Add(dto);

            }
            PagedResponse<HeroDto> response = new PagedResponse<HeroDto>
            {
                Data = heroesDtos,
                MaxPages = (int)Math.Ceiling(maxPages)
            };
            return response;

        }

        public HeroDto TrainHero(Guid heroId)
        {
            Hero hero = _context.Heroes.Find(heroId);
            if (hero == null)
                throw new Exception("400");
            hero.setTrainingCounter();
            if (hero.TrainingCounter == 5)
                throw new Exception("405");
            hero.TrainingCounter++;
            Random rnd = new Random();
            double parcent = rnd.Next(0, 1000);
            double num = 1 + (parcent / 10000);
            hero.CurrentPower = hero.CurrentPower * num;
            if (_context.SaveChanges() > 0)
            {
                HeroDto heroDto = _mapper.Map<HeroDto>(hero);
                heroDto.CanTrain = true;
                return heroDto;
            }
            throw new Exception("500");
        }
    }
}
