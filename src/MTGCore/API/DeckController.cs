using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTGCore.Authentication.Identity;
using MTGCore.Services.Decks;
using MTGCore.ViewModels;

namespace MTGCore.API
{
    // TODO(CD): When auth is implemented, require authentication here
    [Route("api/[controller]")]
    public class DeckController : Controller
    {
        private readonly IDeckService _deckService;

        public DeckController(IDeckService deckService)
        {
            _deckService = deckService;
        }
        
        [Route("{deckID}/add/{cardID}")]
        [HttpPost]
        public async Task<IActionResult> AddCardToDeck(Guid deckId, Guid cardId)
        {
            var identity = User.GetIdentity();
            await _deckService.AddCardToDeck(identity, cardId, deckId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetDecks()
        {
            var identity = User.GetIdentity();
            var decks = await _deckService.GetAllDecks(identity);
            return Ok(decks);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetSingleDeck(Guid id)
        {
            var deck = await _deckService.GetDeck(id);
            return Ok(deck);
        }

        [Route("New")]
        [HttpPost]
        public async Task<IActionResult> AddNewDeck([FromBody] NewDeckViewModel newDeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var identity = User.GetIdentity();
            var deck = await _deckService.AddNewDeck(identity, newDeck.Title, newDeck.Description);
            return Ok(deck);
        }
        
        [Route("{deckID}/remove/{cardID}")]
        [HttpPost]
        public async Task<IActionResult> RemoveCardFromDeck(Guid deckId, Guid cardId)
        {
            var identity = User.GetIdentity();
            await _deckService.RemoveCardFromDeck(identity, cardId, deckId);
            return Ok();
        }
    }
}
