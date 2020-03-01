using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MTGCore.Dtos.Models;
using System.IO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MTGCore.Repository
{
    public class RepoContext : IdentityDbContext, IRepoContext
    {
        public RepoContext(DbContextOptions<RepoContext> options) : base(options) { }

        public virtual DbSet<CardDto> Card { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Deck> Deck { get; set; }
        public virtual DbSet<DeckCards> DeckCards { get; set; } 
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RepoContext>
    {
        public RepoContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../MTGCore/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<RepoContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new RepoContext(builder.Options);
        }

    }
}
