using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!Sets.Any())
                Sets.Add(new Set());

            Set currentSet = Sets.Last();
            int goalsA = currentSet.Goals.Count(goal => goal.Team == Team.TeamA);
            int goalsB = currentSet.Goals.Count(goal => goal.Team == Team.TeamB);
            if (goalsA == 10 || goalsB == 10)
            {
                currentSet = new Set();
                Sets.Add(currentSet);
            }

            currentSet.Goals.Add(new Goal(team));
        }
    }

    public enum Team
    {
        TeamA,
        TeamB
    }

    public class Set
    {
        public IList<Goal> Goals { get; set; } = new List<Goal>();
    }

    public class Goal
    {
        public Team Team { get; set; }

        public Goal(Team team)
        {
            Team = team;
        }
    }
}
