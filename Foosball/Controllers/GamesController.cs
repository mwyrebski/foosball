﻿
using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET api/values
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return _gameRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Game Get(int id)
        {
            return _gameRepository.FindById(id);
        }

        // POST api/values
        [HttpPost("{id}/goal/{team}")]
        public void Post(int id, Team team)
        {
            Game game = _gameRepository.FindById(id);

            game.AddGoal(team);

            _gameRepository.Save(game);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
