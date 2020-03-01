
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTGCore.Models;
using MTGCore.Dtos.Models;
using MTGCore.ViewModels;

namespace MTGCore.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //TODO: refactor this, this is gross. Card => CardDto would be ideal...
            CreateMap<Card,CardDto>();
            CreateMap<CardDto, Card>();

            CreateMap<CardDto, CardViewModel>();

            CreateMap<RegisterModel, User>();
        }

    }
}
