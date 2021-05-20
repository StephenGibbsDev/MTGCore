using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MTGCore.Dtos.Models;
using MTGCore.Services;
using MTGCore.Services.Exceptions;
using MTGCore.Services.Interfaces;
using MTGCore.ViewModels;

namespace MTGCore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly MTGService _mtgService;
        private readonly IMapper _mapper;
        private readonly IManaCostConverter _manaCostConverter;
        // TODO(CD): It could be worth implementing the ILogger interface for a custom logger to give us control over what it does
        private readonly ILogger<SearchController> _logger;

        public SearchController(MTGService mtgservice, IMapper mapper, IManaCostConverter manaCostConverter, ILogger<SearchController> logger)
        {
            _mtgService = mtgservice;
            _mapper = mapper;
            _manaCostConverter = manaCostConverter;
            _logger = logger;
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        public async Task<IEnumerable<CardDtoWithSymbols>> Post([FromBody] FormViewModel form)
        {
            // TODO(CD): Lazy so re-using the CardDto. Since the CardDto is the model the db table is based off,
            // we should probably create a new specific DTO returning only the data we need on the frontend
            
            var response = await _mtgService.GetCardByName(form.Name);

            var cardList = _mapper.Map<List<CardDtoWithSymbols>>(response);
            
            // TODO(CD): Will be nicer when we extract the card stuff into a repo
            cardList.ForEach(IncludeSymbolsWithCard);

            return cardList;
        }

        private void IncludeSymbolsWithCard(CardDtoWithSymbols card)
        {
            try
            {
                card.manaSymbols = _manaCostConverter.Convert(card.manaCost);
            }
            catch (ManaSymbolFactoryException ex)
            {
                _logger.LogWarning(ex, "Something went wrong while converting the mana string {manaCost} for card {card}", card.manaCost, card.id);
            }
        }
    }
}
