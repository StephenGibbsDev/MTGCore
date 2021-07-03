using System;
using System.Collections.Generic;
using MTGCore.Repository.Models;

namespace MTGCore.Services.Decks
{
    public record CardOverview(Guid Id, string Name, IEnumerable<ManaSymbol> ManaSymbols, string ImageUrl, int Quantity);
}