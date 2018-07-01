using System;
using System.Collections.Generic;
using System.Linq;
using Foosball.Domain.Exceptions;

namespace Foosball.Domain
{
    public class Game
    {
        public int GameId { get; set; }

        public DateTime StartedAt { get; set; }

        public IList<Set> Sets { get; set; } = new List<Set>();

        public static Game Create()
        {
            return new Game
            {
                StartedAt = DateTime.UtcNow
            };
        }

        public void AddGoal(Team team)
        {
            if (Status == GameStatus.Finished)
                throw new CannotAddGoalToFinishedGameException();

            if (!Sets.Any())
                Sets.Add(Set.Create());

            Set currentSet = Sets.Last();
            if (currentSet.WonByTeam.HasValue)
            {
                currentSet = Set.Create();
                Sets.Add(currentSet);
            }

            currentSet.Goals.Add(Goal.Create(team));
        }

        public Team? WonByTeam => Sets
            .ToLookup(x => x.WonByTeam)
            .SingleOrDefault(x => x.Count() == 2)?.Key;

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
