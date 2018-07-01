using System.Collections.Generic;
using System.Linq;
using Foosball.Domain;

namespace Foosball.Infrastructure.Persistence
{
    public class GameRepository : IGameRepository
    {
        private readonly FoosballDbContext _dbContext;

        public GameRepository(FoosballDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Game FindById(int id)
        {
            return _dbContext.Games.Find(id);
        }

        public ICollection<Game> GetAll()
        {
            return _dbContext.Games.ToList();
        }

        public void Save(Game game)
        {
            _dbContext.Add(game);
            _dbContext.SaveChanges();
        }
    }
}
