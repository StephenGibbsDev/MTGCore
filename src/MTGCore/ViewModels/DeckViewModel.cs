using MTGCore.Dtos.Models;
using System.Collections.Generic;

namespace MTGCore.ViewModels
{
    public class DeckViewModel
    {
        public IEnumerable<CardAmt> Cards { get; set; }
    }

    public class CardAmt
    {
        public CardDtoWithSymbols Card { get; set; }
        public int Amount { get; set; }
    }
}
