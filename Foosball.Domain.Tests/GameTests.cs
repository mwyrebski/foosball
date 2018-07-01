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

        [Fact]
        public void AddGoal_ShouldCreateNewSet()
        {
            _game.AddGoal(Team.TeamA);

            _game.Sets.Should().HaveCount(1);
        }

        [Fact]
        public void AddGoal_11Times_ShouldCreate2ndSet()
        {
            for (int i = 0; i < 11; i++)
            {
                _game.AddGoal(Team.TeamA);
            }

            _game.Sets.Should().HaveCount(2);
        }

        [Theory]
        [InlineData(Team.TeamA)]
        [InlineData(Team.TeamB)]
        public void AddGoal_10TimesForTheSameTeam_ShouldNotCreate2ndSet(Team team)
        {
            for (int i = 0; i < 10; i++)
            {
                _game.AddGoal(team);
            }

            _game.Sets.Should().HaveCount(1);
        }
    }
}
