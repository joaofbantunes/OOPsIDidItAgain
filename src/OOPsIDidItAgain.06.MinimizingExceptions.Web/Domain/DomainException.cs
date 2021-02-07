using System;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain
{
    public sealed class DomainException<TValue>: Exception 
    {
        public DomainException(Error errorDetail)
        {
            ErrorDetail = errorDetail;
        }

        public Error ErrorDetail { get; }
    }
}