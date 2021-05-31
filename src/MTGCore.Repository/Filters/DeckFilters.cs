using System;
using System.Linq.Expressions;
using MTGCore.Authentication.Identity;
using MTGCore.Repository.Models;

namespace MTGCore.Services.Decks
{
    public static class DeckFilters
    {
        public static Expression<Func<Deck, bool>> FilterByUser(MtgIdentity identity)
        {
            return m => m.UserId == identity.Id;
        }
        
        public static Expression<Func<Deck, bool>> FilterByTitle(string title)
        {
            return m => m.Title == title;
        }
    }
}