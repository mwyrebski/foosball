using System;
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
    }
}
