using Microsoft.AspNetCore.Mvc.Rendering;
using MTGCore.Dtos.Models;
using System.Collections.Generic;

namespace MTGCore.ViewModels
{
    public class CardViewModel
    {
        public string multiverseid { get; set; }
        //TODO: make sure automapper takes an integer of ID not string
        public string id { get; set; }
        public string name { get; set; }
        public string manaCost { get; set; }
        public string cmc { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string rarity { get; set; }
        public string set { get; set; }
        public string artist { get; set; }
        public string power { get; set; }
        public string toughness { get; set; }
        public string imageUrl { get; set; }

        public int DeckID { get; set; }

        public List<SelectListItem> Decks { get;}

        public CardViewModel()
        {

        }
        public CardViewModel(List<SelectListItem> decks)
        {

            Decks = decks;
        }
    }
}
