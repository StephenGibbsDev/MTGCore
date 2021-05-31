using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MTGCore.Authentication.Identity;
using MTGCore.MtgClient.Api.Services;
using MTGCore.Repository;
using MTGCore.Repository.Decks;
using MTGCore.Repository.Models;
using MTGCore.Services.Exceptions;
using MTGCore.Services.Interfaces;

namespace MTGCore.Services.Decks
{
    public class DeckService : IDeckService
    {
        private readonly IDeckRepository _deckRepository;
        private readonly IManaCostConverter _manaCostConverter;
        // TODO(CD): Replace these with a card service
        private readonly IRepoContext _context;
        private readonly IMtgHttpClient _mtgHttpClient;
        private readonly IMapper _mapper;
        // TODO(CD): I think it would be nice to explore a static logger manager we can create a logger
        // instance from without having to inject - At this rate, we'll have a logger dependency in every class
        private readonly ILogger<DeckService> _logger;

        public DeckService(IDeckRepository deckRepository, IManaCostConverter manaCostConverter, ILogger<DeckService> logger, IMtgHttpClient mtgHttpClient, IRepoContext context, IMapper mapper)
        {
            _deckRepository = deckRepository;
            _manaCostConverter = manaCostConverter;
            _logger = logger;
            _mtgHttpClient = mtgHttpClient;
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeckWithCardOverview> GetDeck(Guid id)
        {
            try
            {
                _logger.LogInformation("Getting deck {deckId}", id);
                var deck = await _deckRepository.GetDeckById(id);
                // TODO(CD): Could be worth doing this conversion when we add a card to the deck
                // The main issue is if it fails, either we don't add the card or we add the card with no mana symbols.
                // I'm not a fan of having the conversion in here, it feels like it should be in a card service but I don't
                // want to iterate through the ids and grab a fresh card from a card service as it defeats the purpose
                // of using a navigation property
                var cards = deck.DeckCards.Select(GetCardOverview);
                return new DeckWithCardOverview(deck.Id, deck.Title, deck.Description, deck.UserId, cards);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong while retrieving deck {deckId}", id);
                throw new DeckServiceException($"Something went wrong while retrieving deck {id}", ex);
            }
        }

        public async Task<IEnumerable<DeckOverview>> GetAllDecks(MtgIdentity identity)
        {
            try
            {
                _logger.LogInformation("Getting all decks for user {userId}", identity.Id);
                var decks = await _deckRepository.GetDecks(identity);
                return decks.Select(m => new DeckOverview(m.Id, m.Title));
            }
            catch (Exception ex)
            {
                throw new DeckServiceException($"Something went wrong while retrieving decks for user {identity.Id}", ex);
            }
        }

        public async Task<DeckWithCardOverview> AddNewDeck(MtgIdentity identity, string title, string description)
        {
            try
            {
                var data = new NewDeckData(title, description);
                _logger.LogInformation("Adding a new deck for {userId} with data {data}", identity.Id, data);
                var deck = await _deckRepository.CreateNewDeck(identity, data);
                return await GetDeck(deck.Id);
            }
            catch (Exception ex)
            {
                throw new DeckServiceException($"Something went wrong while adding a new deck for user {identity.Id}", ex);
            }
        }

        public async Task AddCardToDeck(MtgIdentity identity, Guid cardId, Guid deckId)
        {
            try
            {
                // TODO(CD): Add a deck validation service to ensure rules are met for the relevant format
                // TODO(CD): Replace this call with a card service
                var card = await TryCreateAndGetCard(cardId);
                await _deckRepository.AddCardToDeck(identity, card, deckId);
            }
            catch (Exception ex)
            {
                throw new DeckServiceException($"Something went wrong while adding card {cardId} to deck {deckId} for user {identity.Id}", ex);
            }
        }

        public async Task RemoveCardFromDeck(MtgIdentity identity, Guid cardId, Guid deckId)
        {
            try
            {
                // TODO(CD): Same as above
                var card = await TryCreateAndGetCard(cardId);
                await _deckRepository.RemoveCardFromDeck(identity, card, deckId);
            }
            catch (Exception ex)
            {
                throw new DeckServiceException($"Something went wrong while adding card {cardId} to deck {deckId} for user {identity.Id}", ex);
            }
        }

        /// <summary>
        /// This is obsolete, use a card service instead
        /// </summary>
        private async Task<Card> TryCreateAndGetCard(Guid cardId)
        {
            var dbCard = _context.Cards.SingleOrDefault(x => x.Id == cardId);
            if (dbCard == null)
            {
                var card = await _mtgHttpClient.GetCardById(cardId);
                var model = _mapper.Map<Card>(card);

                await _context.Cards.AddAsync(model);
                _context.SaveChanges();
                dbCard = model;
            };
            return dbCard;
        }
        
        private CardOverview GetCardOverview(DeckCards deckCards)
        {
            var card = deckCards.Card;
            
            try
            {
                var manaSymbols = _manaCostConverter.Convert(card.ManaCost);
                return new CardOverview(card.Id, card.Name, manaSymbols, card.ImageUrl, deckCards.Quantity);
            }
            catch (ManaSymbolFactoryException ex)
            {
                _logger.LogWarning(ex, "Something went wrong while converting the mana string {manaCost} for card {card}", card.ManaCost, card.Id);
                return new CardOverview(card.Id, card.Name, Enumerable.Empty<ManaSymbol>(), card.ImageUrl, deckCards.Quantity);
            }
        }
    }
}