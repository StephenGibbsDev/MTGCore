using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using MTGCore.Authentication.Identity;
using MTGCore.Repository.Models;

namespace MTGCore.Repository
{
    public class RepoContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IRepoContext
    {
        public RepoContext(DbContextOptions<RepoContext> options) : base(options) { }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Deck> Decks { get; set; }
        public virtual DbSet<DeckCards> DeckCards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            const string adminId = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            base.OnModelCreating(builder);

            builder.Entity<DeckCards>()
                .HasKey(m => new {m.DeckId, m.CardId});
            builder.Entity<DeckCards>()
                .HasOne(m => m.Deck)
                .WithMany(m => m.DeckCards)
                .HasForeignKey(m => m.DeckId);
            builder.Entity<DeckCards>()
                .HasOne(m => m.Card)
                .WithMany(m => m.DeckCards)
                .HasForeignKey(m => m.CardId);
            
            var user = new AppUser
            {
                Id = Guid.Parse(adminId),
                UserName = "TestUser",
                NormalizedUserName = "TESTUSER",
                Email = "test@test.test",
                NormalizedEmail = "TEST@TEST.TEST",
                EmailConfirmed = true,
                
            };
            
            var passwordHasher = new PasswordHasher<AppUser>();
            passwordHasher.HashPassword(user, "Test.1234");
            
            builder.Entity<AppUser>().HasData(user);
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RepoContext>
    {
        public RepoContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
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
