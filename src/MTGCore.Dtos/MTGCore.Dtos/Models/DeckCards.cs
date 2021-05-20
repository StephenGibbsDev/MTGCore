namespace MTGCore.Dtos.Models
{
    public class DeckCards
    {
        public int Id { get; set; }
        public CardDto Card { get; set; }
        // TODO(CD): int?
        public string CardID { get; set; }

        public Deck Deck { get; set; }
        public int DeckID { get; set; }

    }
}
