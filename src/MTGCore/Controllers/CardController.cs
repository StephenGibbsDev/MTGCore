using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTGCore.Dtos.Models;
using MTGCore.Models;
using MTGCore.Repository;
using MTGCore.Services;
using Newtonsoft.Json;

namespace MTGCore.Controllers
{
    public class CardController : Controller
    {
        private MTGService _mtgService;
        private IMapper _mapper;
        private readonly IRepoContext _context;

        public CardController(MTGService mtgservice, IMapper mapper, IRepoContext context)
        {
            _mtgService = mtgservice;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ActionResult> Index(int Page)
        {

            var response = await _mtgService.GetCardsByPage(Page);


            var cardList = _mapper.Map<List<Cards>>(response);

            if (response == null)
                return NotFound();

            return View(cardList);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var response = await _mtgService.GetCardByID(id);

             var model = _mapper.Map<Cards>(response);

            if (response == null)
                return NotFound();

            return View(model);
        }
    }
}