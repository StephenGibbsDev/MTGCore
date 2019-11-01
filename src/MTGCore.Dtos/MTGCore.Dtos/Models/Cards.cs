using System;

namespace MTGCore.Dtos
{
    public class Cards
    {
        public Card[] CardList {get;set;}

        public class Card
        {
            public string Name { get; set; }
            public string ManaCost { get; set; }    
            public string ConvertedManaCost { get; set; }
            public string Type { get; set; }
            public string CardText { get; set; }
            public string Rarity { get; set; }
            public string Set { get; set; }
            public string Artist { get; set; }
        }

        
    }
}
