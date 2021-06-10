using System.Collections.Generic;

namespace MTGCore.ViewModels
{
    public class SearchFilter
    {
        [Filter(1)]
        public string Name { get; set; }

        [Filter(2)]
        public string Type { get; set; }

        [Filter(3)]
        public string Rarity { get; set; }

        public string Set { get; set; }


        public string ColoursOption { get; set; }

        [Filter(5)]
        public List<string> Colours { get; set; }
    }
}
