using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainException domainException)
            {
                context.Result = domainException.ErrorDetail.Accept(new ResultMappingErrorVisitor());
            }
            else
            {
                // nope, we shouldn't return the exception message to the client, just for demo
                context.Result = new ObjectResult(context.Exception.Message)
                    {StatusCode = (int) HttpStatusCode.InternalServerError};
            }
            context.ExceptionHandled = true;
        }
    }
}