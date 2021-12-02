using AutoMapper;
using Heroes_Api.Dtos;
using Heroes_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Hero, HeroDto>()
                .ForMember(dest => dest.CanTrain, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
