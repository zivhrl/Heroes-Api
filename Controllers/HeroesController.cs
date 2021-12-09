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
       

        public HeroesController(IHeroesRepository repo)
        {
            _heroesRepo = repo;
        }


        [HttpGet]
        public IActionResult getHeroes([FromQuery] GetOptions opts)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("400");
            }
            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            PagedResponse<HeroDto> pagedHeroes=_heroesRepo.getHeroes(opts,currentUserId);
            if (pagedHeroes == null)
            {
                throw new Exception("500");
            }
            return Ok(pagedHeroes);
        }

        [HttpPatch("{id}")]
        public ActionResult TrainHero(Guid id)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!_heroesRepo.checkOwnership(id, currentUserId))
            {
                throw new Exception("400");
            }
            HeroDto heroDto = _heroesRepo.TrainHero(id);
            if (heroDto == null)
            {
                throw new Exception("500");
            }
            return Ok(heroDto);
        }
    }
}
