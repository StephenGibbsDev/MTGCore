using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTGCore.Dtos.Models;
using MTGCore.Repository;
using MTGCore.Services;
using MTGCore.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MTGCore.API
{
    [Route("api/[controller]")]
    public class DeckController : Controller
    {
        private readonly IRepoContext _context;
        private MTGService _mtgService;
        private IMapper _mapper;

        public DeckController(IRepoContext context, MTGService mtgservice, IMapper mapper)
        {
            _context = context;
            _mtgService = mtgservice;
            _mapper = mapper;
        }

        //api/deck/
        [Route("Add/{deckID}/{cardID}")]
        [HttpPost]
        public async Task Post(int deckID, string cardID)
        {

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

        [Route("{Id}")]
        [HttpGet]
        public async Task<DeckViewModel>Get(int Id)
        {

            var list = _context.DeckCards.Include(x => x.Card).Include(x => x.Deck).Where(x => x.DeckID == Id).ToList();
            var results = list.GroupBy(g => g.CardID).ToList();

            List<CardAmt> cardAmt = new List<CardAmt>();

            foreach (var group in results)
            {
                CardAmt ca1 = new CardAmt();
                CardDto card = new CardDto();

                var groupKey = group.Key;
                ca1.Amount = group.Count();

                card = group.FirstOrDefault().Card;

                ca1.Card = card;
                cardAmt.Add(ca1);
            }

            DeckViewModel deckViewModel = new DeckViewModel() { Cards = cardAmt };

            return deckViewModel;
        }

        [Route("New/{title}")]
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
