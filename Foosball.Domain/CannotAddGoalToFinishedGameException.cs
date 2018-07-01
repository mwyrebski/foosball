using System;

namespace Foosball.Domain
{
    public class CannotAddGoalToFinishedGameException : Exception
    {
        public CannotAddGoalToFinishedGameException()
            : base("Cannot add goal to a Finished game")
        {
        }
    }
}
