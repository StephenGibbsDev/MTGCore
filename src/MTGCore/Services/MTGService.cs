using MTGCore.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using MTGCore.ViewModels;
using Microsoft.AspNetCore.WebUtilities;

namespace MTGCore.Services
{
    public class MTGService
    {
        public const string ProxiedClient = "test";
        private HttpClient _client;
        //change this base URL to a fiield in the appsettings.json and pull here and tests
        //public string _baseUrl = "https://api.magicthegathering.io/v1/";
        public string _baseUrl = "https://localhost:44317/v1/";

        public MTGService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<Card> GetCardByMultiverseID(int multiverseID)
        {
            var result = await _client.GetAsync($"cards/{multiverseID}  ");

            if (!result.IsSuccessStatusCode)
                return default;

            var stream = await result.Content.ReadAsStringAsync();

            var singleCard = JsonConvert.DeserializeObject<RootObject>(stream).card;

            return singleCard;
        }

        public async Task<Card> GetCardByID(string Id)
        {
            var result = await _client.GetAsync($"cards/{Id}");

            if (!result.IsSuccessStatusCode)
                return default;

            var stream = await result.Content.ReadAsStringAsync();

            var singleCard = JsonConvert.DeserializeObject<RootObject>(stream).card;

            return singleCard;
        }


        public async Task<List<Card>> GetCardByName(string name)
        {
            var result = await _client.GetAsync($"cards?name={name}");

            if (!result.IsSuccessStatusCode)
                return default;

            var stream = await result.Content.ReadAsStringAsync();

            var cardList = JsonConvert.DeserializeObject<RootObject>(stream).cards;

            return cardList;
        }

        public async Task<List<Card>> GetCardBySearchFilter(IEnumerable<KeyValuePair<string,string>> filters)
        {

            var url = QueryHelpers.AddQueryString("cards", filters);
            var result = await _client.GetAsync(url);

            if (!result.IsSuccessStatusCode)
                return default;

            var stream = await result.Content.ReadAsStringAsync();

            var cardList = JsonConvert.DeserializeObject<RootObject>(stream).cards;

            return cardList;
        }

        public async Task<List<Card>> GetCardsByPage(int PageID)
        {
            var result = await _client.GetAsync($"cards?page={PageID}");

            if (!result.IsSuccessStatusCode)
                return default;

            var stream = await result.Content.ReadAsStringAsync();

            var cardList = JsonConvert.DeserializeObject<RootObject>(stream).cards;

            return cardList;
        }

    }
}
