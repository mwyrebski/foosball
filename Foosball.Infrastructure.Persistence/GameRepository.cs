using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Task<Game> FindByIdAsync(int id)
        {
            return _dbContext.Games
                .Include(x => x.Sets)
                .ThenInclude(x => x.Goals)
                .SingleOrDefaultAsync(game => game.GameId == id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _dbContext.Games
                .Include(x => x.Sets)
                .ThenInclude(x => x.Goals)
                .OrderByDescending(x => x.Started);
        }

        public async Task SaveAsync(Game game)
        {
            if (game.GameId == 0)
                await _dbContext.AddAsync(game);
            else
                _dbContext.Update(game);
            await _dbContext.SaveChangesAsync();
        }
    }
}
