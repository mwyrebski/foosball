using System.Collections.Generic;
using System.Linq;

namespace Foosball.Domain
{
    public class Game
    {
        public int GameId { get; set; }

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
}
