using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTGCore.Dtos.Models;
using MTGCore.Models;
using MTGCore.Repository;
using MTGCore.Services;
using MTGCore.Services.Interfaces;
using Newtonsoft.Json;

namespace MTGCore.Controllers
{
    public class CardController : Controller
    {
        private MTGService _mtgService;
        private IMapper _mapper;
        private readonly IRepoContext _context;
        private readonly IConversionService _conversion;
        private readonly IWebHostEnvironment _env;

        public CardController(MTGService mtgservice, IMapper mapper, IRepoContext context, IConversionService conversion, IWebHostEnvironment env)
        {
            _mtgService = mtgservice;
            _mapper = mapper;
            _context = context;
            _conversion = conversion;
            _env = env;
        }

        public async Task<ActionResult> Index(int Page)
        {

            var response = await _mtgService.GetCardsByPage(Page);

            string rootPath = _env.WebRootPath;

            response.Select(x => { x.manaCost = _conversion.ConvertToSymbol(x.manaCost, @$"{rootPath}\images\"); return x; }).ToList();

            var cardList = _mapper.Map<List<Cards>>(response);

            if (response == null)
                return NotFound();

            return View(cardList);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var response = await _mtgService.GetCardByID(id);

            string rootPath = _env.WebRootPath;

            response.manaCost = _conversion.ConvertToSymbol(response.manaCost, @$"{rootPath}\images\");

            var model = _mapper.Map<Cards>(response);

            if (response == null)
                return NotFound();

            return View(model);
        }
    }
}

