using Duende.IdentityServer.EntityFramework.Options;
using IdentityAPIWorkshop.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IdentityAPIWorkshop.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

        public DbSet<GameModel> Games { get; set; }
        public DbSet<HighscoreModel> Highscores { get; set; }
    }
}