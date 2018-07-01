using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foosball.Domain
{
    public interface IGameRepository
    {
        Task<Game> FindByIdAsync(int id, CancellationToken cancellationToken);
        IEnumerable<Game> GetAll();
        Task SaveAsync(Game game, CancellationToken cancellationToken);
    }
}
