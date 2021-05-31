using System.Collections.Generic;

namespace MTGCore.MtgClient.Api.Models.Card
{
    public class CardApiResponse
    {
        public List<CardApiObject> cards { get; set; }
        public CardApiObject card { get; set; }
    }
}
