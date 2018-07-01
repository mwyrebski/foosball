using System.Collections.Generic;
using System.Threading.Tasks;
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
        public IEnumerable<Game> GetAll()
        {
            return _gameRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Task<Game> Get(int id)
        {
            return _gameRepository.FindByIdAsync(id);
        }

        [HttpPost]
        public IActionResult Post()
        {
            Game game = Game.Create();

            _gameRepository.SaveAsync(game);

            return CreatedAtAction(nameof(Get), new {id = game.GameId}, game);
        }

        [HttpPost("{id}/goal/{team}")]
        public async Task<IActionResult> Post(int id, Team team)
        {
            Game game = await _gameRepository.FindByIdAsync(id);
            if (game == null)
                return NotFound();

            game.AddGoal(team);

            await _gameRepository.SaveAsync(game);
            return Ok(game);
        }
    }
}
