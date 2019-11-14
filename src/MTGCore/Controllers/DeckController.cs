using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTGCore.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MTGCore.Controllers
{
    public class DeckController : Controller
    {
        private readonly IRepoContext _context;

        public DeckController(IRepoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var decks = _context.Decks.ToList();


            return View(decks);
        }

        public void AddToDeck(int Id)
        {
            
            


        }
    }
}
