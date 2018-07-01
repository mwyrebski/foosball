using Foosball.Domain;
using Microsoft.EntityFrameworkCore;

namespace Foosball.Infrastructure.Persistence
{
    public class FoosballDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Goal> Goals { get; set; }
    }
}
