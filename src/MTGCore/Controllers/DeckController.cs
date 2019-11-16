using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MTGCore.Dtos.Models;
using MTGCore.Repository;
using MTGCore.Services;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MTGCore.Controllers
{
    public class DeckController : Controller
    {
        private MTGService _mtgService;
        private readonly IRepoContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DeckController(IRepoContext context, MTGService mtgservice, UserManager<IdentityUser> userManager)
        {
            _mtgService = mtgservice;
            _context = context;
            _userManager = userManager;
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

        public async Task AddCardAsync(int id)
        {
            var response = await _mtgService.GetCardByID(id);

        }
    }
}
