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
        [Route("Add/{deckID}/{multiverseID}")]
        [HttpPost]
        public async Task Post(int deckID, int multiverseID)
        {

            var deckCard = new DeckCards();

            //get card from service
            var card = await _mtgService.GetCardByID(multiverseID);

            //map to dto
            var model = _mapper.Map<CardDto>(card);

            deckCard.CardID = card.id;
            deckCard.DeckID = deckID;

            //insert card into db if it doesnt exist
            var dbCard = _context.Card.Where(x => x.id == card.id).SingleOrDefault();

            if (dbCard == null)
            {
                _context.Card.Add(model);
                _context.SaveChanges();
            };

            //insert into deckcard
            _context.DeckCards.Add(deckCard);
            _context.SaveChanges();

        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<DeckViewModel>Get(int Id)
        {

            var list = _context.DeckCards.Include(x => x.Card).Include(x => x.Deck).Where(x => x.DeckID == 1).ToList();
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
    }
}
