using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Foosball.Domain.Tests
{
    public class GameTests
    {
        private readonly Game _game;

        public GameTests()
        {
            _game = Game.Create();
        }

        [Fact]
        public void Create_ShouldPassAndReturnNotNull()
        {
            _game.Should().NotBeNull();
        }

        [Fact]
        public void Create_ShouldCreateGameWithEmptySets()
        {
            _game.Sets.Should().BeEmpty();
        }

        [Theory]
        [InlineData(Team.TeamA)]
        [InlineData(Team.TeamB)]
        public void AddGoal_ShouldPassForBothTeams(Team team)
        {
            _game.AddGoal(team);
        }
    }
}
