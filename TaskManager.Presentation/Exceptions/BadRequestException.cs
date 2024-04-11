using System;

namespace TaskManager.Presentation.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string businessMessage)
            : base(businessMessage)
        {
        }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}