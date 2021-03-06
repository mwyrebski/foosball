﻿using System.Collections.Generic;
using System.Threading;
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
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            Game game = await _gameRepository.FindByIdAsync(id, cancellationToken);
            if (game == null)
                return NotFound();
            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameAsync(CancellationToken cancellationToken)
        {
            Game game = Game.Create();

            await _gameRepository.SaveAsync(game, cancellationToken);

            return CreatedAtAction(nameof(GetByIdAsync), new {id = game.GameId}, game);
        }

        [HttpPost("{id}/goal/{team}")]
        public async Task<IActionResult> AddGoalToGameAsync(int id, Team team, CancellationToken cancellationToken)
        {
            Game game = await _gameRepository.FindByIdAsync(id, cancellationToken);
            if (game == null)
                return NotFound();

            game.AddGoal(team);

            await _gameRepository.SaveAsync(game, cancellationToken);
            return Ok(game);
        }
    }
}
