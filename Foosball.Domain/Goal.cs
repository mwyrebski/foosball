namespace Foosball.Domain
{
    public class Goal
    {
        public Team Team { get; set; }

        public Goal(Team team)
        {
            Team = team;
        }
    }
}