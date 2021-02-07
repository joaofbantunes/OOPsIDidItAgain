using System;

namespace OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
                
        }
    }
}