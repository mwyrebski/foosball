namespace Foosball.Domain
{
    public class Goal
    {
        public int GoalId { get; set; }

        public Team Team { get; set; }

        public Goal(Team team)
        {
            Team = team;
        }
    }
}