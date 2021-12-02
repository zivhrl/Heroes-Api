using AutoMapper;
using Heroes_Api.Contracts;
using Heroes_Api.Dtos;
using Heroes_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Heroes_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroesController : Controller
    {
        private IHeroesRepository _heroesRepo;
        private IMapper _mapper;
        public HeroesController(IHeroesRepository repo,IMapper mapper)
        {
            _heroesRepo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult getHeroes([FromQuery] GetOptions opts)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            List<HeroDto> heroesDtos=new List<HeroDto>();
            PagedResponse<Hero> pagedHeroes;
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (opts.filterForTrainer)
            {
                pagedHeroes = _heroesRepo.getHeroes(opts, currentUserID);
            }
            else
                pagedHeroes = _heroesRepo.getHeroes(opts, "");
            foreach(Hero hero in pagedHeroes.Data)
            {
                hero.setTrainingCounter();
                HeroDto dto = _mapper.Map<HeroDto>(hero);
                dto.CanTrain = hero.User.Id == currentUserID;
                heroesDtos.Add(dto);

            }
            PagedResponse<HeroDto> response = new PagedResponse<HeroDto>
            {
                Data = heroesDtos,
                MaxPages=pagedHeroes.MaxPages
            };
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public ActionResult TrainHero(Guid id)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!_heroesRepo.checkOwnership(id, currentUserID))
                return BadRequest();
            Hero hero = _heroesRepo.TrainHero(id);
            if (hero == null)
                return BadRequest();
            HeroDto heroDto = _mapper.Map<HeroDto>(hero);
            heroDto.CanTrain = true;
            return Ok(heroDto);
        }
    }
}
