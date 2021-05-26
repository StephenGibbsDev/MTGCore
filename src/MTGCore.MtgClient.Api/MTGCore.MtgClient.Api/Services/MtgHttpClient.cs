using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MTGCore.MtgClient.Api.Exceptions;
using MTGCore.MtgClient.Api.Models.Card;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;

namespace MTGCore.MtgClient.Api.Services
{
    public class MtgHttpClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<MtgHttpClient> _logger;

        public MtgHttpClient(HttpClient client, ILogger<MtgHttpClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<CardApiObject> GetCardByMultiverseId(int multiverseId)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, $"cards/{multiverseId}");
            var result = await PerformRequest<CardApiResponse>(message);
            return result.card;
        }

        public async Task<CardApiObject> GetCardById(string id)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, $"cards/{id}");
            var result = await PerformRequest<CardApiResponse>(message);
            return result.card;
        }


        public async Task<IEnumerable<CardApiObject>> GetCardByName(string name)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, $"cards?name={name}");
            var result = await PerformRequest<CardApiResponse>(message);
            return result.cards;
        }

        public async Task<IEnumerable<CardApiObject>> GetCardsByPage(int pageId)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, $"cards?page={pageId}");
            var result = await PerformRequest<CardApiResponse>(message);
            return result.cards;
        }

        private async Task<T> PerformRequest<T>(HttpRequestMessage request)
        {
            _logger.LogInformation("Making a HTTP request: {request}", request);
            
            try
            {
                using var result = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                result.EnsureSuccessStatusCode();
                
                var options = new JsonSerializerOptions
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
                };

                await using var stream = await result.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<T>(stream, options);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An occurred while making a HTTP request");
                throw new MtgClientException($"An error occurred while making a request to '{request}'", ex);
            }
            
        }
    }
}
