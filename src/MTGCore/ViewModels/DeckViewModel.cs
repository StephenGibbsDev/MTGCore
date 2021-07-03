using System.Collections.Generic;
using MTGCore.Repository.Models;

namespace MTGCore.ViewModels
{
    public class DeckViewModel
    {
        public IEnumerable<CardAmt> Cards { get; set; }
    }

    public class CardAmt
    {
        public CardWithSymbols Card { get; set; }
        public int Amount { get; set; }
    }
}
