using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTGCore.Dtos.Models;
using MTGCore.Repository;
using MTGCore.Services;
using MTGCore.Services.Interfaces;
using MTGCore.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MTGCore.API
{
    [Route("api/[controller]")]
    public class DeckController : Controller
    {
        private readonly IRepoContext _context;
        private readonly MTGService _mtgService;
        private readonly IMapper _mapper;
        private readonly IManaCostConverter _manaCostConverter;

        public DeckController(IRepoContext context, MTGService mtgservice, IMapper mapper, IManaCostConverter manaCostConverter)
        {
            _context = context;
            _mtgService = mtgservice;
            _mapper = mapper;
            _manaCostConverter = manaCostConverter;
        }

        //api/deck/
        [Route("Add/{deckID}/{cardID}")]
        [HttpPost]
        public async Task Post(int deckID, string cardID)
        {
            // TODO(CD): Requires refactoring
            var deckCard = new DeckCards();

            deckCard.CardID = cardID;
            deckCard.DeckID = deckID;

            // cant make this block async as the _context.deckcards.add rely on a card in the database
            //insert card into db if it doesnt exist
            var dbCard = _context.Card.Where(x => x.id == cardID).SingleOrDefault();
            if (dbCard == null)
            {
                var card = await _mtgService.GetCardByID(cardID);
                var model = _mapper.Map<CardDto>(card);

                _context.Card.Add(model);
                _context.SaveChanges();
            };

            //insert into deckcard
            _context.DeckCards.Add(deckCard);
            _context.SaveChanges();

        }

        [HttpGet]
        public List<Deck> Get()
        {
            return _context.Deck.ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<DeckViewModel> Get(int id)
        {
            // TODO(CD): This should probably be moved into a store/repository
            var list = await _context.DeckCards.Include(x => x.Card).Include(x => x.Deck).Where(x => x.DeckID == id).ToListAsync();
            var results = list.GroupBy(g => g.CardID);
            var cardAmt = results.Select(m => new CardAmt { Card = AddManaSymbolsToCard(m.FirstOrDefault()?.Card), Amount = m.Count() });
            return new DeckViewModel { Cards = cardAmt };
        }

        private CardDtoWithSymbols AddManaSymbolsToCard(CardDto card)
        {
            // TODO(CD): If we move the card stuff into a store/repository, we can then do the mana cost conversion directly in there, saving us from having to do
            // it everytime we want to retrieve the mana symbols.
            var cardWithSymbols = _mapper.Map<CardDtoWithSymbols>(card);
            cardWithSymbols.manaSymbols = _manaCostConverter.Convert(card.manaCost);
            return cardWithSymbols;
        }

        [Route("New")]
        [HttpPost]
        public int? AddNewDeck(string title)
        {
            var deck = _context.Deck.Where(m => m.Title == title).SingleOrDefault();

            if(deck != null)
            {
                throw new Exception("Deck with that name already exists!");
            }

            Deck newDeck = new Deck() { Title = title };
            _context.Deck.Add(newDeck);
            _context.SaveChanges();
            return newDeck.Id;
        }
    }
}
