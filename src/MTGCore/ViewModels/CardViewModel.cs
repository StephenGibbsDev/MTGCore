using Microsoft.AspNetCore.Mvc.Rendering;
using MTGCore.Dtos.Models;
using System.Collections.Generic;

namespace MTGCore.ViewModels
{
    public class CardViewModel
    {
        public Deck selectedDeck { get; set; }
        public CardDto Card { get;}

        public string multiverseid { get; set; }

        public List<SelectListItem> Decks { get;}

        public CardViewModel()
        {

        }
        public CardViewModel(CardDto card, List<SelectListItem> decks)
        {
            Card = card;
            Decks = decks;
        }
    }
}
