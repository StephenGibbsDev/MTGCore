using System;
using System.Collections.Generic;
using MTGCore.Services.Interfaces;

namespace MTGCore.Services
{
    public class ManaStringParser : IManaStringParser
    {
        public IEnumerable<string> Parse(string manaCost)
        {
            if (string.IsNullOrEmpty(manaCost))
            {
                throw new InvalidOperationException($"The mana cost string can not be parsed as it's in the incorrect format.");
            }
            
            return manaCost.Split(new[] { "{", "}" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}