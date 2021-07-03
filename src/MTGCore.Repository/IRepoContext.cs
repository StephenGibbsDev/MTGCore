using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using MTGCore.Repository.Models;

namespace MTGCore.Repository
{

    public interface IRepoContext : IDisposable
    {
        //TODO: theres a way of doing this with generics but cannot figure out a way to do it.
        //this would be preferential as you would only need to add properties in the context and not here as well.
        DbSet<Card> Cards { get; set; }
        DbSet<Deck> Decks { get; set; }
        DbSet<DeckCards> DeckCards { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}