using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MTGCore.Authentication.Identity;

namespace MTGCore.Services.Decks
{
    public interface IDeckService
    {
        Task<DeckWithCardOverview> GetDeck(Guid id);
        Task<IEnumerable<DeckOverview>> GetAllDecks(MtgIdentity identity);
        Task<DeckWithCardOverview> AddNewDeck(MtgIdentity identity, string title, string description);
        Task AddCardToDeck(MtgIdentity identity, Guid cardId, Guid deckId);
        Task RemoveCardFromDeck(MtgIdentity identity, Guid cardId, Guid deckId);
    }
}