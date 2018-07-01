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
            if (Status == GameStatus.Finished)
                throw new CannotAddGoalToFinishedGameException();

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

        public Team? WonByTeam
        {
            get
            {
                int setsWonByA = Sets.Count(set => set.WonByTeam == Team.TeamA);
                int setsWonByB = Sets.Count(set => set.WonByTeam == Team.TeamB);

                if (setsWonByA == 2)
                    return Team.TeamA;
                if (setsWonByB == 2)
                    return Team.TeamB;
                return null;
            }
        }

        public GameStatus Status
        {
            get
            {
                if (WonByTeam.HasValue)
                    return GameStatus.Finished;
                if (Sets.Any())
                    return GameStatus.InProgress;
                return GameStatus.NotStarted;
            }
        }
    }

    public enum GameStatus
    {
        NotStarted,
        InProgress,
        Finished
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
