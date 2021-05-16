using System.Collections.Generic;

namespace MTGCore.Services.Interfaces
{
    public interface IManaStringParser
    {
        IEnumerable<string> Parse(string manaCost);
    }
}