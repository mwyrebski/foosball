using Foosball.Domain;
using Microsoft.EntityFrameworkCore;

namespace Foosball.Infrastructure.Persistence
{
    public class FoosballDbContext : DbContext
    {
        public FoosballDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Goal> Goals { get; set; }
    }
}
