using System.Collections.Generic;
using MTGCore.Repository.Models;

namespace MTGCore.Services.Interfaces
{
    public interface IManaCostConverter
    {
        IEnumerable<ManaSymbol> Convert(string manaCost);
    }
}
