using MTGCore.Dtos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.ViewModels
{
    public class DeckViewModel
    {
        public List<CardAmt> Cards { get; set; }
    }

    public class CardAmt
    {
        public CardDto Card { get; set; }
        public int Amount { get; set; }
    }
}
