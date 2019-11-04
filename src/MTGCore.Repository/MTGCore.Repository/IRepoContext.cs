using Microsoft.EntityFrameworkCore;
using MTGCore.Dtos.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTGCore.Repository
{

    public interface IRepoContext : IDisposable
    {
        //TODO: theres a way of doing this with generics but cannot figure out a wway to do it.
        //this wwould be preferential as you would only need to add properties in the context and not here as wwell.
        DbSet<Cards> Cards { get; set; }
        DbSet<Decks> Decks { get; set; }
        DbSet<DeckCards> DeckCards { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}