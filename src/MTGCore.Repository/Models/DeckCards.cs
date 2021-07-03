using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTGCore.Repository.Models
{
    public class DeckCards
    {
        [ForeignKey("Card")]
        public Guid CardId { get; private set; }
        public Card Card { get; set; }
        [ForeignKey("Deck")]
        public Guid DeckId { get; private set; }
        public Deck Deck { get; set; }
        public int Quantity { get; set; }

        public void IncrementQuantity()
        {
            Quantity++;
        }
        
        public void DecrementQuantity()
        {
            Quantity--;
        }
    }
}