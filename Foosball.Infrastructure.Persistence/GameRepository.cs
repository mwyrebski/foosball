using System.Collections.Generic;
using System.Linq;
using Foosball.Domain;
using Microsoft.EntityFrameworkCore;

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
            return _dbContext.Games
                .Include(x => x.Sets)
                .ThenInclude(x => x.Goals)
                .SingleOrDefault(game => game.GameId == id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _dbContext.Games
                .Include(x => x.Sets)
                .ThenInclude(x => x.Goals)
                .OrderByDescending(x => x.Started);
        }

        public void Save(Game game)
        {
            if (game.GameId == 0)
                _dbContext.Add(game);
            else
                _dbContext.Update(game);
            _dbContext.SaveChanges();
        }
    }
}
