using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTGCore.Dtos.Models;
using MTGCore.Models;
using MTGCore.Repository;
using MTGCore.Services;
using MTGCore.Services.Interfaces;
using MTGCore.ViewModels;
using Newtonsoft.Json;

namespace MTGCore.Controllers
{
    public class CardController : Controller
    {
        private MTGService _mtgService;
        private IMapper _mapper;
        private readonly IRepoContext _context;
        private readonly IConversionService _conversion;
        private readonly UserManager<IdentityUser> _userManager;

        public CardController(MTGService mtgservice, IMapper mapper, IRepoContext context, IConversionService conversion, UserManager<IdentityUser> userManager)
        {
            _mtgService = mtgservice;
            _mapper = mapper;
            _context = context;
            _conversion = conversion;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index(int Page)
        {

            var response = await _mtgService.GetCardsByPage(Page);


            response.Select(x => { x.manaCost = _conversion.ConvertToSymbol(x.manaCost); return x; }).ToList();

            var cardList = _mapper.Map<List<CardDto>>(response);

            if (response == null)
                return NotFound();

            return View(cardList);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var response = await _mtgService.GetCardByID(id);

            response.manaCost = _conversion.ConvertToSymbol(response.manaCost);

            var model = _mapper.Map<CardDto>(response);

            var UserIDString = _userManager.GetUserId(HttpContext.User);

            var userId = new Guid(UserIDString);

            var myDecks = _context.Deck.Where(x => x.UserID == userId).ToList();

            var selectList = myDecks.Select(x =>
            new SelectListItem()
            {
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList();

            CardViewModel cardVM = new CardViewModel(selectList);

            cardVM.multiverseid = model.multiverseid;
            cardVM.name = model.name;

            if (response == null)
                return NotFound();

            return View(cardVM);
        }
    }
}

