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
            if (currentSet.WonByTeam.HasValue)
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

        public Team? WonByTeam
        {
            get
            {
                int goalsA = Goals.Count(goal => goal.Team == Team.TeamA);
                if (goalsA == 10)
                    return Team.TeamA;
                int goalsB = Goals.Count(goal => goal.Team == Team.TeamB);
                if (goalsB == 10)
                    return Team.TeamB;
                return null;
            }
        }
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
