using MTGCore.HelperClasses;
using System.Collections.Generic;


namespace MTGCore.Models
{
    public class Card
    {
        public string name { get; set; }
        private string _manaCost;
        public string manaCost { get { return _manaCost; } set { _manaCost = ManaConvert.String(value); } }
        public double cmc { get; set; }
        public List<object> colors { get; set; }
        public List<object> colorIdentity { get; set; }
        public string type { get; set; }
        public List<object> supertypes { get; set; }
        public List<string> types { get; set; }
        public List<object> subtypes { get; set; }
        public string rarity { get; set; }
        public string set { get; set; }
        public string setName { get; set; }
        public string text { get; set; }
        public string artist { get; set; }
        public string number { get; set; }
        public string layout { get; set; }
        public int multiverseid { get; set; }
        public string imageUrl { get; set; }
        public List<object> rulings { get; set; }
        public List<object> foreignNames { get; set; }
        public List<string> printings { get; set; }
        public string originalText { get; set; }
        public string originalType { get; set; }
        public List<Legality> legalities { get; set; }
        public string id { get; set; }
        public string flavor { get; set; }
        public string power { get; set; }
        public string toughness { get; set; }
        public List<string> variations { get; set; }
    }
}
