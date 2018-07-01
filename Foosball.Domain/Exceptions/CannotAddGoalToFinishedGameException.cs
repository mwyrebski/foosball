namespace Foosball.Domain.Exceptions
{
    public sealed class CannotAddGoalToFinishedGameException : FoosballInvalidDataException
    {
        public CannotAddGoalToFinishedGameException()
            : base("Cannot add goal to a Finished game")
        {
        }
    }
}
