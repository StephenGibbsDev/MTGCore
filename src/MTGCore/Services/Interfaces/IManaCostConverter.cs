using System.Collections.Generic;
using MTGCore.Dtos.Models;

namespace MTGCore.Services.Interfaces
{
    public interface IManaCostConverter
    {
        IEnumerable<ManaSymbol> Convert(string manaCost);
    }
}
