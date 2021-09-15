using AutoMapper;
using MTGCore.MtgClient.Api.Models.Card;
using MTGCore.Repository.Models;
using MTGCore.ViewModels;

namespace MTGCore.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //TODO: refactor this, this is gross. Card => CardDto would be ideal...
            CreateMap<CardApiObject, Card>().ReverseMap();
            CreateMap<Card, CardWithSymbols>();
            CreateMap<CardApiObject, CardWithSymbols>();
            CreateMap<Card, CardViewModel>();
        }

    }
}
