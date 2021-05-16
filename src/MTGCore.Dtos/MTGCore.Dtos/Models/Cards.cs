using System.Collections.Generic;

namespace MTGCore.Dtos.Models
{
    public class CardDto
    {
        // TODO(CD): We should capitalise these property names really
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
    }
    
    // TODO(CD): Each class should have it's own file
    // We should change this to have only the properties required for the frontend from the table model
    public class CardDtoWithSymbols : CardDto
    {
        public IEnumerable<ManaSymbol> manaSymbols { get; set; }
    }
}
