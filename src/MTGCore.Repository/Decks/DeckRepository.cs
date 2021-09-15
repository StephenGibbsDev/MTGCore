using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MTGCore.Authentication.Identity;
using MTGCore.Repository.Exceptions;
using MTGCore.Repository.Extensions;
using MTGCore.Repository.Models;
using MTGCore.Services.Decks;

namespace MTGCore.Repository.Decks
{
    internal class DeckRepository : IDeckRepository
    {
        private readonly IRepoContext _context;
        private readonly ILogger<DeckRepository> _logger;

        public DeckRepository(ILogger<DeckRepository> logger, IRepoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Deck> CreateNewDeck(MtgIdentity identity, NewDeckData newDeckData)
        {
            EnsureDeckDoesNotExist(identity, newDeckData.Title);
            var newDeck = Deck.New(identity, newDeckData);
            await _context.Decks.AddAsync(newDeck);
            _context.SaveChanges();
            return newDeck;
        }

        public async Task<Deck> GetDeckById(Guid deckId)
        {
            return await _context.Decks.Where(m => m.Id == deckId).Include(m => m.DeckCards).ThenInclude(m => m.Card).FirstOrDefaultAsync();
        }
        
        public async Task<IEnumerable<Deck>> GetDecks(MtgIdentity identity)
        {
            var filters = new []
            {
                DeckFilters.FilterByUser(identity)
            };

            return await _context.Decks.Filter(filters).ToListAsync();
        }

        public async Task AddCardToDeck(MtgIdentity identity, Card card, Guid deckId)
        {
            var deck = await GetDeckById(deckId);
            deck.EnsureOwnership(identity);
            HandleDeckCardStoreModification(deck, card, DeckCardStoreAction.AddCard);
            _context.SaveChanges();
        }
        
        public async Task RemoveCardFromDeck(MtgIdentity identity, Card card, Guid deckId)
        {
            var deck = await GetDeckById(deckId);
            deck.EnsureOwnership(identity);
            HandleDeckCardStoreModification(deck, card, DeckCardStoreAction.RemoveCard);
            _context.SaveChanges();
        }

        private void EnsureDeckDoesNotExist(MtgIdentity identity, string title)
        {
            var filters = new []
            {
                DeckFilters.FilterByUser(identity),
                DeckFilters.FilterByTitle(title)
            };
            
            var matchingDecks = _context.Decks.Filter(filters: filters);
            if (Enumerable.Any(matchingDecks))
            {
                _logger.LogError("Adding a new deck for user {userId} failed as one already existed with the same title.", identity.Id);
                throw new DuplicateResourceException("A deck with this title already exists.");
            }
        }

        private void HandleDeckCardStoreModification(Deck deck, Card card, DeckCardStoreAction action)
        {
            // A service/repo for the DeckCards might be overkill
            var deckCard = deck.DeckCards.SingleOrDefault(m => m.CardId == card.Id);

            if (deckCard == null)
            {
                HandleNullDeckCardStoreModification(deck, card, action);
                return;
            }

            switch (action)
            {
                case DeckCardStoreAction.AddCard:
                    deckCard.IncrementQuantity();
                    _logger.LogInformation("Received action {action}. Adding card {cardId} to deck {deckId} resulting in a matching card quantity of {quantity}.", action, card.Id, deck.Id, deckCard.Quantity);
                    break;
                case DeckCardStoreAction.RemoveCard:
                    deckCard.DecrementQuantity();
                    _logger.LogInformation("Received action {action}. Removing card {cardId} from deck {deckId} with a matching card quantity of {quantity} remaining.", action, card.Id, deck.Id, deckCard.Quantity);
                    break;
                default:
                    throw new InvalidOperationException($"Unknown action: {action}");
            }

            if (deckCard.Quantity == 0)
            {
                _logger.LogInformation("The card {cardId} was completely removed from deck {deckId} due to having a quantity of 0.", card.Id, deck.Id);
                _context.DeckCards.Remove(deckCard);
                return;
            }

            _context.DeckCards.Update(deckCard);
        }

        private void HandleNullDeckCardStoreModification(Deck deck, Card card, DeckCardStoreAction action)
        {
            if (action == DeckCardStoreAction.RemoveCard)
            {
                _logger.LogWarning("The card {cardId} could not be removed as it did not exist within deck {deckId}.", card.Id, deck.Id);
                return;
            }
            
            _logger.LogInformation("Attempting to add card {cardId} to deck {deckId} with a quantity of 1.", card.Id, deck.Id);
            var deckCards = new DeckCards { Deck = deck, Card = card, Quantity = 1 };
            deck.DeckCards.Add(deckCards);
        }

        private enum DeckCardStoreAction
        {
            AddCard,
            RemoveCard
        }
    }
}