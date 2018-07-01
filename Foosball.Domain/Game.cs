using System;
using System.Collections.Generic;
using System.Text;

namespace Foosball.Domain
{
    public class Game
    {
        public IList<Set> Sets { get; set; } = new List<Set>();

        public static Game Create()
        {
            return new Game();
        }

        public void AddGoal(Team team)
        {
        }
    }

    public enum Team
    {
        TeamA,
        TeamB
    }

    public class Set
    {
    }
}
