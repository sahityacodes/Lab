using System;

namespace BusinessLogic.Exceptions
{
    public class UserDefinedException : Exception
    {
        public UserDefinedException()
        {
        }

        public UserDefinedException(string message)
            : base(message)
        {
        }
    }
}
