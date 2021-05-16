using MTGCore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using MTGCore.Dtos.Models;

namespace MTGCore.Services
{
    public class ManaCostConverter : IManaCostConverter
    {
        private readonly IManaSymbolFactory _manaSymbolFactory;
        private readonly IManaStringParser _manaStringParser;

        public ManaCostConverter(IManaSymbolFactory manaSymbolFactory, IManaStringParser manaStringParser)
        {
            _manaSymbolFactory = manaSymbolFactory;
            _manaStringParser = manaStringParser;
        }

        public IEnumerable<ManaSymbol> Convert(string manaCost)
        {
            var manaArr = _manaStringParser.Parse(manaCost);
            return manaArr.Select(_manaSymbolFactory.Build);
        }
    }
}
