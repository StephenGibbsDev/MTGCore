using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.Models
{
    public class RootObject
    {
        public List<Card> cards { get; set; }
        public Card card { get; set; }
    }
}
