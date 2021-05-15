using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MTGCore.Dtos.Models;
using System.IO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;

namespace MTGCore.Repository
{
    public class RepoContext : IdentityDbContext, IRepoContext
    {
        public RepoContext(DbContextOptions<RepoContext> options) : base(options) { }

        public virtual DbSet<CardDto> Card { get; set; }
        public virtual DbSet<Deck> Deck { get; set; }
        public virtual DbSet<DeckCards> DeckCards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            base.OnModelCreating(builder);

            var user = new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "TestUser",
                NormalizedUserName = "TESTUSER",
                Email = "test@test.test",
                NormalizedEmail = "TEST@TEST.TEST",
                EmailConfirmed = true
            };

            var deck = new Deck
            {
                Id=  1,
                Title = "Test Deck",
                UserID = new Guid(ADMIN_ID),
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            passwordHasher.HashPassword(user, "Test.1234");

            builder.Entity<IdentityUser>().HasData(user);
            builder.Entity<Deck>().HasData(deck);
        }
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
