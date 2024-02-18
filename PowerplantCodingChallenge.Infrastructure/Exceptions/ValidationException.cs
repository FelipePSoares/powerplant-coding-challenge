using System;

namespace PowerplantCodingChallenge.Infrastructure.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string property, string message) : base(message)
        {
            this.Property = property;
        }

        public string Property { get; }
    }
}
