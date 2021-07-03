using System;
using Microsoft.Extensions.DependencyInjection;
using MTGCore.MtgClient.Api.Services;

namespace MTGCore.MtgClient.Api
{
    public static class MtgClientDependencyBundle
    {
        public static void RegisterMtgClient(this IServiceCollection services)
        {
            // TODO(CD): Turn into an env var
            const string baseUrl = "https://localhost:44317/v1/";
            services.AddHttpClient<IMtgHttpClient, MtgHttpClient>("MTG", client => client.BaseAddress = new Uri(baseUrl));
        }
    }
}