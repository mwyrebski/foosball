using System.Collections.Generic;

namespace Foosball.Domain
{
    public interface IGameRepository
    {
        ICollection<Game> GetAll();
        void Save(Game game);
    }
}
