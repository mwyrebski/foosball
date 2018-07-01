using System;
using System.Collections.Generic;
using System.Text;

namespace Foosball.Domain
{
    public class Game
    {
        private int _goals;
        public IList<Set> Sets { get; set; } = new List<Set>();

        public static Game Create()
        {
            return new Game();
        }

        public void AddGoal(Team team)
        {
            if (_goals == 0 || _goals == 10 || _goals == 20)
                Sets.Add(new Set());

            _goals++;
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
