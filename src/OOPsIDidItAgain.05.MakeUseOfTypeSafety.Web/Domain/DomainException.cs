using System;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain
{
    public class DomainException : Exception
    {
        public DomainException(ErrorDetail errorDetail)
        {
            ErrorDetail = errorDetail;
        }

        public ErrorDetail ErrorDetail { get; }
    }
}