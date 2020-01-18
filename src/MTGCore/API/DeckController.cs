using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTGCore.Dtos.Models;
using MTGCore.Repository;
using MTGCore.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MTGCore.API
{
    [Route("api/[controller]")]
    public class DeckController : Controller
    {
        private readonly IRepoContext _context;

        public DeckController(IRepoContext context)
        {
            _context = context;
        }

        //api/deck/5
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
