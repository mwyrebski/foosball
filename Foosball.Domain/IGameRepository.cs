using System.Collections.Generic;

namespace Foosball.Domain
{
    public interface IGameRepository
    {
        Game FindById(int id);
        ICollection<Game> GetAll();
        void Save(Game game);
    }
}
