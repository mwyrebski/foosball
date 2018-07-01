using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Foosball.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Create_ShouldPassAndReturnNotNull()
        {
            var game = Game.Create();

            game.Should().NotBeNull();
        }

        [Fact]
        public void Create_ShouldCreateGameWithEmptySets()
        {
            var game = Game.Create();

            game.Sets.Should().BeEmpty();
        }

        [Theory]
        [InlineData(Team.TeamA)]
        [InlineData(Team.TeamB)]
        public void AddGoal_ShouldPassForBothTeams(Team team)
        {
            var game = Game.Create();

            game.AddGoal(team);
        }
    }
}
