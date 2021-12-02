using Heroes_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Contracts
{
    public interface IHeroesRepository
    {
        PagedResponse<Hero> getHeroes(GetOptions options,string UserId);
        Hero TrainHero(Guid heroId);
        bool checkOwnership(Guid heroId, string userId);
    }
}
