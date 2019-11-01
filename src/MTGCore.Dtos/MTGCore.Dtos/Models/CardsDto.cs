using System;

namespace MTGCore.Dtos
{
    public class CardsDto
    {
        public card[] CardList {get;set;}

        public class card
        {
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
        }

        
    }
}
