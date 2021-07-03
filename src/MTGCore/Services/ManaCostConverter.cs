using System;
using MTGCore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using MTGCore.Repository.Models;

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
            if (!TryParse(manaCost, out var manaArr))
            {
                return Enumerable.Empty<ManaSymbol>();
            }
            
            return manaArr.Select(_manaSymbolFactory.Build).ToList();
        }

        private bool TryParse(string manaCost, out IEnumerable<string> parsedStringArray)
        {
            try
            {
                parsedStringArray = _manaStringParser.Parse(manaCost);
                return true;
            }
            catch (InvalidOperationException ex)
            {
                // TODO(CD): Log ex here maybe
                parsedStringArray = Enumerable.Empty<string>();
                return false;
            }
        }
    }
}
