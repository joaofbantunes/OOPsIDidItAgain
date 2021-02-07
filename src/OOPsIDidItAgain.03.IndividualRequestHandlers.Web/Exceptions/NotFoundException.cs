using System;

namespace OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message) : base(message)
        {
                
        }
    }
}