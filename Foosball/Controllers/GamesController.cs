using System.Collections.Generic;
using Foosball.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Foosball.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public GamesController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return _gameRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Game Get(int id)
        {
            return _gameRepository.FindById(id);
        }

        [HttpPost("{id}/goal/{team}")]
        public void Post(int id, Team team)
        {
            Game game = _gameRepository.FindById(id);

            game.AddGoal(team);

            _gameRepository.Save(game);
        }
    }
}
