using System;

namespace OOPsIDidItAgain._04.OOifying.Web.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message) : base(message)
        {
                
        }
    }
}