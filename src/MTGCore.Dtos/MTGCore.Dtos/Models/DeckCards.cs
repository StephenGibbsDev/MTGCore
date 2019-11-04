using System;
using System.Collections.Generic;
using System.Text;

namespace MTGCore.Dtos.Models
{
    public class DeckCards
    {
        public int Id { get; set; }
        public Cards Card { get; set; }
        public string CardID { get; set; }

        public Decks Deck { get; set; }
        public int DeckID { get; set; }

    }
}
