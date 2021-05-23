using AutoMapper;
using MTGCore.Dtos.Models;
using MTGCore.MtgClient.Api.Models.Card;
using MTGCore.ViewModels;

namespace MTGCore.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //TODO: refactor this, this is gross. Card => CardDto would be ideal...
            CreateMap<CardApiObject, CardDto>().ReverseMap();
            CreateMap<CardDto, CardDtoWithSymbols>();
            CreateMap<CardApiObject, CardDtoWithSymbols>();
            CreateMap<CardDto, CardViewModel>();
        }

    }
}
