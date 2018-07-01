using System.IO;
using Foosball.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Foosball.Infrastructure.Persistence
{
    public class FoosballDbContext : DbContext, IDesignTimeDbContextFactory<FoosballDbContext>
    {
        public FoosballDbContext()
        {
        }

        public FoosballDbContext(DbContextOptions options) : base(options)
        {
        }

        public FoosballDbContext CreateDbContext(string[] args)
        {
            string basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Foosball");
            Directory.SetCurrentDirectory(basePath);

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<FoosballDbContext>();
            builder.UseSqlite(configuration.GetConnectionString("FoosballDatabase"));
            return new FoosballDbContext(builder.Options);

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Goal> Goals { get; set; }
    }
}
