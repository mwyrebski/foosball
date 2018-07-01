using System;

namespace Foosball.Domain
{
    public class Goal
    {
        public int GoalId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Team Team { get; set; }

        public static Goal Create(Team team)
        {
            return new Goal
            {
                Team = team,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}