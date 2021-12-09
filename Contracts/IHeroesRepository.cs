using Heroes_Api.Dtos;
using Heroes_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Contracts
{
    public interface IHeroesRepository
    {
        PagedResponse<HeroDto> getHeroes(GetOptions options,string UserId);
        HeroDto TrainHero(Guid heroId);
        bool checkOwnership(Guid heroId, string userId);
    }
}
