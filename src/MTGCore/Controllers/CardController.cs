using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MTGCore.Dtos;
using MTGCore.Models;
using MTGCore.Services;
using Newtonsoft.Json;

namespace MTGCore.Controllers
{
    public class CardController : Controller
    {
        private MTGService _mtgService;
        private IMapper _mapper;

        public CardController(MTGService mtgservice, IMapper mapper)
        {
            _mtgService = mtgservice;
            _mapper = mapper;

        }

        public async Task<ActionResult> Index(int Page)
        {
            var response = await _mtgService.GetCardsByPage(Page);

            if (response == null)
                return NotFound();

            return View(response);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var response = await _mtgService.GetCardByID(id);

             var model = _mapper.Map<CardsDto.card>(response);

            if (response == null)
                return NotFound();

            return View(model);

        }
    }
}