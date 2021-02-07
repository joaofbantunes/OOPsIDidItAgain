using System;

namespace OOPsIDidItAgain._04.OOifying.Web.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
                
        }
    }
}