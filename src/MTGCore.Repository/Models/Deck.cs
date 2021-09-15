using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security;
using MTGCore.Authentication.Identity;
using MTGCore.Repository.Decks;

namespace MTGCore.Repository.Models
{
    public class Deck
    {
        [Key]
        public Guid Id { get; private set; }
        [Required]
        public Guid UserId { get; private set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public List<DeckCards> DeckCards { get; set; }

        public static Deck New(MtgIdentity identity, NewDeckData data)
        {
            return new (data.Title, data.Description, identity.Id);
        }

        public void EnsureOwnership(MtgIdentity identity)
        {
            if (!UserId.Equals(identity.Id))
            {
                throw new SecurityException($"User {identity.Id} does not have permissions to modify deck {Id}.");
            }
        }
        
        // For EF Core binding
        private Deck()
        {
            DeckCards = new List<DeckCards>();
        }
        
        private Deck(string title, string description, Guid userId)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            UserId = userId;
        }
    }
}
