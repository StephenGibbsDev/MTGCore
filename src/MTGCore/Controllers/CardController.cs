using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MTGCore.Dtos.Models;
using MTGCore.Repository;
using MTGCore.Services;
using MTGCore.Services.Interfaces;
using MTGCore.ViewModels;

namespace MTGCore.Controllers
{
    public class CardController : Controller
    {
        private MTGService _mtgService;
        private IMapper _mapper;
        private readonly IRepoContext _context;
        private readonly IManaCostConverter _manaCostConverter;
        private readonly UserManager<IdentityUser> _userManager;

        public CardController(MTGService mtgservice, IMapper mapper, IRepoContext context, IManaCostConverter manaCostConverter, UserManager<IdentityUser> userManager)
        {
            _mtgService = mtgservice;
            _mapper = mapper;
            _context = context;
            _manaCostConverter = manaCostConverter;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index(int Page)
        {
            // TODO(CD): We should probably switch the mtgService into a repository (mtgClient)
            // We could then inject it into a mtgService and do the mana conversion in there which will be much nicer
            // It might be better for it to happen in the proxy
            var response = await _mtgService.GetCardsByPage(Page);
            var cardList = _mapper.Map<List<CardDto>>(response);
            // TODO(CD): Currently uncommented for a quick fix as these controllers are not even used by the Vue js frontend
            // cardList.ForEach(m => m.manaSymbols = _manaCostConverter.Convert(m.manaCost));

            if (response == null)
                return NotFound();

            return View(cardList);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var response = await _mtgService.GetCardByMultiverseID(id);

            var model = _mapper.Map<CardDto>(response);
            // TODO(CD): Currently uncommented for a quick fix as these controllers are not even used by the Vue js frontend
            // model.manaSymbols = _manaCostConverter.Convert(model.manaCost);

            var userIDString = _userManager.GetUserId(HttpContext.User);
            if (!Guid.TryParse(userIDString, out var userId))
            {
                userId = new Guid();
            }

            var myDecks = _context.Deck.Where(x => x.UserID == userId).ToList();

            var selectList = myDecks.Select(x =>
            new SelectListItem()
            {
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList();
                

            CardViewModel cardVM = _mapper.Map<CardViewModel>(model);

            cardVM.AddDeck(selectList);

            if (response == null)
                return NotFound();

            return View(cardVM);
        }
    }
}

