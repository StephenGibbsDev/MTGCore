using System;
using System.Collections.Generic;
using MTGCore.Services.Interfaces;

namespace MTGCore.Services
{
    public class ManaStringParser : IManaStringParser
    {
        public IEnumerable<string> Parse(string manaCost)
        {
            // TODO(CD): I'm wondering if it would be worth adding a check to ensure it is a valid string?
            return manaCost.Split(new[] { "{", "}" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}