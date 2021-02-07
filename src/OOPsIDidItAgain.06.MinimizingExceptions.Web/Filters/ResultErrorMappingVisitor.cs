using System;
using Microsoft.AspNetCore.Mvc;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Filters
{
    public struct ResultErrorMappingVisitor<TValue, TModel> : Error.IResultVisitor<ActionResult<TModel>>
    {

        public ActionResult<TModel> Visit(Error.NotFound result)
            => new NotFoundObjectResult(result.Message);

        public ActionResult<TModel> Visit(Error.Invalid result)
            => new BadRequestObjectResult(result.Message);
        
//        public IActionResult Visit(Error.Unexpected result)
//            => new ObjectResult(result.Message) {StatusCode = (int) HttpStatusCode.InternalServerError};
    }
}