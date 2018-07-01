using System;

namespace Foosball.Domain.Exceptions
{
    public class FoosballException : Exception
    {
        public FoosballException()
        {
        }

        public FoosballException(string message) : base(message)
        {
        }

        public FoosballException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}