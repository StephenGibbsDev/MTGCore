using System.Collections.Generic;
using MTGCore.Configuration.Exceptions;
using MTGCore.Configuration.Interfaces;

namespace MTGCore.Configuration
{
    public class ManaSymbolImageMap : IManaSymbolImageMap
    {
        private readonly IDictionary<string, string> _imageMap = new Dictionary<string, string>
        {
            { "0", "colorless-0.svg" },
            { "1", "colorless-1.svg" },
            { "2", "colorless-2.svg" },
            { "3", "colorless-3.svg" },
            { "4", "colorless-4.svg" },
            { "5", "colorless-5.svg" },
            { "6", "colorless-6.svg" },
            { "7", "colorless-7.svg" },
            { "8", "colorless-8.svg" },
            { "9", "colorless-9.svg" },
            { "10", "colorless-10.svg" },
            { "11", "colorless-11.svg" },
            { "12", "colorless-12.svg" },
            { "X", "colorless-x.svg" },
            { "W", "white.svg" },
            { "2W", "white-2.svg" },
            { "U", "blue.svg" },
            { "2U", "blue-2.svg" },
            { "R", "red.svg" },
            { "2R", "red-2.svg" },
            { "G", "green.svg" },
            { "2G", "green-2.svg" },
            { "B", "black.svg" },
            { "2B", "black-2.svg" },
            { "C", "colorless.svg" }
        };
        
        public string GetValue(string manaSymbol)
        {
            if (_imageMap.TryGetValue(manaSymbol, out var imageUrl))
            {
                return imageUrl;
            }
            
            throw new MapException($"Mana symbol {manaSymbol} does not have a mapping set-up.");
        }
    }
}