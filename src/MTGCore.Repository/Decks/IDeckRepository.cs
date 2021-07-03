using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MTGCore.Authentication.Identity;
using MTGCore.Repository.Models;

namespace MTGCore.Repository.Decks
{
    public interface IDeckRepository
    {
        Task<Deck> CreateNewDeck(MtgIdentity identity, NewDeckData newDeckData);
        Task<Deck> GetDeckById(Guid deckId);
        Task<IEnumerable<Deck>> GetDecks(MtgIdentity identity);
        Task AddCardToDeck(MtgIdentity identity, Card card, Guid deckId);
        Task RemoveCardFromDeck(MtgIdentity identity, Card card, Guid deckId);
    }
}