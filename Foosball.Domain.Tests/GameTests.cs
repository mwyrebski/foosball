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
            AddGoals(11, Team.TeamA);

            _game.Sets.Should().HaveCount(2);
        }

        [Theory]
        [InlineData(Team.TeamA)]
        [InlineData(Team.TeamB)]
        public void AddGoal_10TimesForTheSameTeam_ShouldNotCreate2ndSet(Team team)
        {
            AddGoals(10, team);

            _game.Sets.Should().HaveCount(1);
        }

        [Fact]
        public void AddGoal_21Times_ShouldCreate3rdSet()
        {
            AddGoals(21, Team.TeamA);

            _game.Sets.Should().HaveCount(3);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(5, 5)]
        [InlineData(9, 1)]
        [InlineData(1, 9)]
        [InlineData(7, 7)]
        [InlineData(9, 9)]
        public void AddGoal_EachTeamScoresLessThan10Goals_ShouldNotCreate2ndSet(int goalsA, int goalsB)
        {
            AddGoals(goalsA, Team.TeamA);
            AddGoals(goalsB, Team.TeamB);

            _game.Sets.Should().HaveCount(1);
        }

        [Theory]
        [InlineData(10, 0, Team.TeamA)]
        [InlineData(10, 9, Team.TeamA)]
        [InlineData(0, 10, Team.TeamB)]
        [InlineData(9, 10, Team.TeamB)]
        public void AddGoal_OneTeamScores10Goals_ScoringTeamShouldWin1stSet(int goalsA, int goalsB, Team expectedWinningTeam)
        {
            AddGoals(goalsA, Team.TeamA);
            AddGoals(goalsB, Team.TeamB);

            _game.Sets[0].WonByTeam.Should().Be(expectedWinningTeam);
        }

        [Theory]
        [InlineData(Team.TeamA, 10, 0, Team.TeamA)]
        [InlineData(Team.TeamB, 10, 0, Team.TeamA)]
        [InlineData(Team.TeamA, 10, 9, Team.TeamA)]
        [InlineData(Team.TeamB, 10, 9, Team.TeamA)]
        [InlineData(Team.TeamA, 0, 10, Team.TeamB)]
        [InlineData(Team.TeamB, 0, 10, Team.TeamB)]
        [InlineData(Team.TeamA, 9, 10, Team.TeamB)]
        [InlineData(Team.TeamB, 9, 10, Team.TeamB)]
        public void AddGoal_TeamScores10GoalsIn2ndSet_ScoringTeamOf2ndSetShouldWin2stSet(
            Team teamWinning1StSet, int goalsAset2, int goalsBset2, Team expectedWinningTeamOf2NdSet)
        {
            AddGoals(10, teamWinning1StSet);
            AddGoals(goalsAset2, Team.TeamA);
            AddGoals(goalsBset2, Team.TeamB);

            _game.Sets[1].WonByTeam.Should().Be(expectedWinningTeamOf2NdSet);
        }

        private void AddGoals(int numberOfGoals, Team team)
        {
            for (int i = 0; i < numberOfGoals; i++)
            {
                _game.AddGoal(team);
            }
        }
    }
}
