using System.Collections.Generic;
using System.Linq;

namespace Foosball.Domain
{
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
}