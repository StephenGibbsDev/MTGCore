using MTGCore.Models;
using MTGCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.Services
{
    public class ManaConversionService : IConversionService
    {
        public Card Convert(Card cardToBeConverted)
        {
            return HandleCardConversion(cardToBeConverted) ?? cardToBeConverted;
        }

        public List<Card> Convert(List<Card> cardsToBeConverted)
        {
            Card ReturnedCard;
            foreach(Card card in cardsToBeConverted)
            {
                 ReturnedCard = HandleCardConversion(card);
                if(ReturnedCard != null)
                {
                    card.manaCost = ReturnedCard.manaCost;
                }
                 
            }
            
            return cardsToBeConverted;
        }

        private Card HandleCardConversion(Card card)
        {
            if(card.manaCost == null)
            {
                return null;
            }

            string manaCost = card.manaCost;

            string[] sections = manaCost.Split(new string[] { "{", "}" }, StringSplitOptions.RemoveEmptyEntries);

            if (sections.Length == 0)
            {
                return null;
            }

            string output = "";
            foreach (string section in sections)
            {
                output += string.Format($"<img src=\"/images/{section}.svg\" height=\"20\" width=\"20\" />");
            }
            card.manaCost = output;

            return card;
        }
    }
}
