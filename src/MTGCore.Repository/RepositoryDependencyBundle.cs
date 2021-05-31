using Microsoft.Extensions.DependencyInjection;
using MTGCore.Repository.Decks;

namespace MTGCore.Repository
{
    public static class RepositoryDependencyBundle
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IDeckRepository, DeckRepository>();
        }
    }
}