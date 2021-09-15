using MTGCore.Repository.Models;

namespace MTGCore.Services.Interfaces
{
    public interface IManaSymbolFactory
    {
        ManaSymbol Build(string manaSymbol);
    }
}