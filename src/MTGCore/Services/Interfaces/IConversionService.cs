using MTGCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.Services.Interfaces
{
    public interface IConversionService
    {
        Card Convert(Card ToBeConverted);
        List<Card> Convert(List<Card> ToBeConverted);
    }
}
