using MTGCore.Dtos.Models;

namespace MTGCore.Services.Interfaces
{
    public interface IManaSymbolFactory
    {
        ManaSymbol Build(string manaSymbol);
    }
}