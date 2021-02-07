using System.Net;
using Microsoft.AspNetCore.Mvc;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Filters
{
    public class ResultMappingErrorVisitor : ErrorDetail.IResultVisitor<IActionResult>
    {
        public IActionResult Visit(ErrorDetail.NotFound result)
            => new NotFoundObjectResult(result.Message);

        public IActionResult Visit(ErrorDetail.Invalid result)
            => new BadRequestObjectResult(result.Message);

        // public IActionResult Visit(ErrorDetail.Unexpected result)
        //     => new ObjectResult(result.Message) {StatusCode = (int) HttpStatusCode.InternalServerError};
    }
}