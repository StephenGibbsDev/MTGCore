using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTGCore.Repository;
using MTGCore.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MTGCore.Controllers
{
    public class DeckController : Controller
    {
        private MTGService _mtgService;
        private readonly IRepoContext _context;

        public DeckController(IRepoContext context, MTGService mtgservice)
        {
            _mtgService = mtgservice;
            _context = context;
        }

        public IActionResult Index()
        {
            var decks = _context.Decks.ToList();


            return View(decks);
        }

        public async Task AddCardAsync(int id)
        {
            var response = await _mtgService.GetCardByID(id);

        }
    }
}
