﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTGCore.Dtos.Models;
using MTGCore.Repository;
using MTGCore.Services;
using MTGCore.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MTGCore.Controllers
{
    public class DeckController : Controller
    {
        private MTGService _mtgService;
        private readonly IRepoContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private IMapper _mapper;


        public DeckController(IRepoContext context, IMapper mapper, MTGService mtgservice, UserManager<IdentityUser> userManager)
        {
            _mtgService = mtgservice;
            _context = context;
            _userManager = userManager;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult View()
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

            return View(deckViewModel);

        }


        public IActionResult Index()
        {
            var UserIDString = _userManager.GetUserId(HttpContext.User);

            if (UserIDString == null)
            {
                return NotFound();
            }

            var userId = new Guid(UserIDString);

            var decks = _context.Deck.Where(x => x.UserID == userId);

            return View(decks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Deck newdeck = new Deck();

            return View(newdeck);
        }

        [HttpPost]
        public IActionResult Create(Deck deck)
        {
            var UserIDString = _userManager.GetUserId(HttpContext.User);

            deck.UserID = new Guid(UserIDString);

            _context.Deck.Add(deck);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var deck = _context.Deck.SingleOrDefault(x => x.Id == Id);

            return View(deck);
        }

        [HttpPost]
        public IActionResult Edit(Deck editedDeck)
        {

            var deck = _context.Deck.SingleOrDefault(x => x.Id == editedDeck.Id);

            var UserIDString = _userManager.GetUserId(HttpContext.User);
            deck.UserID = new Guid(UserIDString);
            deck.Title = editedDeck.Title;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task AddToDeckAsync(CardViewModel cardVM)
        {

            var deckCard = new DeckCards();

            //get card from service
            var card = await _mtgService.GetCardByMultiverseID(Convert.ToInt32(cardVM.multiverseid));

            //map to dto
            var model = _mapper.Map<CardDto>(card);

            deckCard.CardID = card.id;
            deckCard.DeckID = cardVM.DeckID;

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
    }
}
