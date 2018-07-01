using System;

namespace Foosball.Domain.Exceptions
{
    public class FoosballInvalidDataException : FoosballException
    {
        public FoosballInvalidDataException()
        {
        }

        public FoosballInvalidDataException(string message) : base(message)
        {
        }

        public FoosballInvalidDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}