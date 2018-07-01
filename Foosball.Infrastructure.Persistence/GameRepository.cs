using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public Task<Game> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _dbContext.Games
                .Include(x => x.Sets)
                .ThenInclude(x => x.Goals)
                .SingleOrDefaultAsync(game => game.GameId == id, cancellationToken);
        }

        public IEnumerable<Game> GetAll()
        {
            return _dbContext.Games
                .Include(x => x.Sets)
                .ThenInclude(x => x.Goals)
                .OrderByDescending(x => x.StartedAt);
        }

        public async Task SaveAsync(Game game, CancellationToken cancellationToken)
        {
            if (game.GameId == 0)
                await _dbContext.AddAsync(game, cancellationToken);
            else
                _dbContext.Update(game);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
