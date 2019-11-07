using MTGCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.Services.Interfaces
{
    public interface IConversionService
    {
         string ConvertToSymbol(string manaCost);

    }
}
