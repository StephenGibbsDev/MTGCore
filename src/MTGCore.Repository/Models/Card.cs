using System;
using System.Collections.Generic;

namespace MTGCore.Repository.Models
{
    public class Card
    {
        public string MultiverseId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ManaCost { get; set; }
        public string Cmc { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string Rarity { get; set; }
        public string Set { get; set; }
        public string Artist { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string ImageUrl { get; set; }
        public List<DeckCards> DeckCards { get; private set; }
        
        // For EF Core binding
        protected Card()
        {
            DeckCards = new List<DeckCards>();
        }
    }
    
    // TODO(CD): Actually this is shit, I'm going to work towards ensuring we don't use this anywhere
    public class CardWithSymbols : Card
    {
        public IEnumerable<ManaSymbol> ManaSymbols { get; set; }
    }
}
