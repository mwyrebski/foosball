using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foosball.Domain
{
    public interface IGameRepository
    {
        Task<Game> FindByIdAsync(int id);
        IEnumerable<Game> GetAll();
        Task SaveAsync(Game game);
    }
}
