using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MTGCore.MtgClient.Api.Models.Card;

namespace MTGCore.MtgClient.Api.Services
{
    public interface IMtgHttpClient
    {
        Task<CardApiObject> GetCardByMultiverseId(int multiverseId);
        Task<CardApiObject> GetCardById(Guid id);
        Task<IEnumerable<CardApiObject>> GetCardByName(string name);
        Task<IEnumerable<CardApiObject>> GetCardsByPage(int pageId);
    }
}