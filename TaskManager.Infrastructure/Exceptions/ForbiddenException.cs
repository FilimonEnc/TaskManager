﻿namespace TaskManager.Infrastructure.Exceptions
{
    public class ForbiddenException : Exception
    {

        public ForbiddenException()
               : base("Недостаточно прав для выполнения данной команды")
        {
        }

        public ForbiddenException(string businessMessage)
               : base(businessMessage)
        {
        }

        public ForbiddenException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
