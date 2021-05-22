using System.Collections.Generic;

namespace MTGCore.ViewModels
{
    public class SearchFilter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Rarity { get; set; }
        public string Set { get; set; }
        public string Price { get; set; }
    }

    public class SearchFilterWithColours : SearchFilter
    {
        public string ColoursOption { get; set; }
        public List<string> Colours { get; set; }
    }

    public class SearchFilterOptions
    {
        public Dictionary<string, object> QueryStringPairs { get; set; }
    }

}
