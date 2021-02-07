using System;

namespace OOPsIDidItAgain._02.SuperService.Web.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message) : base(message)
        {
                
        }
    }
}