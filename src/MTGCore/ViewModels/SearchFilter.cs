using System.Collections.Generic;

namespace MTGCore.ViewModels
{
    public class SearchFilter
    {
        public string Type { get; set; }
        public string ColoursOption { get; set; }
        public List<string> Colours { get; set; }
        public string Rarity { get; set; }
        public string Set { get; set; }
        public string Price { get; set; }
    }
}
