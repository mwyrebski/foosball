using Foosball.Domain;
using Microsoft.EntityFrameworkCore;

namespace Foosball.Infrastructure.Persistence
{
    public class FoosballDbContext : DbContext
    {
        public FoosballDbContext()
        {
        }

        public FoosballDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Foosball.configure.db");
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Goal> Goals { get; set; }
    }
}
