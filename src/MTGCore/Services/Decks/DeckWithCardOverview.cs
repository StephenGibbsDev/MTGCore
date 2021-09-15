using System;
using System.Collections.Generic;

namespace MTGCore.Services.Decks
{
    public record DeckWithCardOverview(Guid Id, string Title, string Description, Guid Owner, IEnumerable<CardOverview> Cards);
}