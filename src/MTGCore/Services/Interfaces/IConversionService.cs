using MTGCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.Services.Interfaces
{
    public interface IConversionService
    {
        // Programming to an interface
        // This should act as a blueprint to show what needs to be implemented
        // The implementation can change, but the blueprint should remain the same after publish
         string ConvertToSymbol(string manaCost);

    }
}
