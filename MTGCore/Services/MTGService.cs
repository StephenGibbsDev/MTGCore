using MTGCore.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MTGCore.Services
{
    public class MTGService
    {
        private HttpClient _client;
        private const string _baseUrl = "https://api.magicthegathering.io/v1/";

        public MTGService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<Card> GetCardByID(int multiverseID)
        {
            var result = await _client.GetAsync($"cards/{multiverseID}");

            if (!result.IsSuccessStatusCode)
                return default;

            var stream = await result.Content.ReadAsStringAsync();

            var singleCard = JsonConvert.DeserializeObject<RootObject>(stream).card;

            return singleCard;
        }

        public async Task<List<Card>> GetCardsByPage(int PageID)
        {
            var result = await _client.GetAsync($"cards?page={PageID}");

            if (!result.IsSuccessStatusCode)
                return default;

            var stream = await result.Content.ReadAsStringAsync();

            var singleCard = JsonConvert.DeserializeObject<RootObject>(stream).cards;

            return singleCard;
        }


    }
}
