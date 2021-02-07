using System;
using Microsoft.AspNetCore.Mvc;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Controllers
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult(this Either<Error, Unit> result)
            => result
                .Fold(
                    error => error.MapError<Unit>().Result,
                    _ => new NoContentResult());

        
        public static ActionResult<TValue> ToActionResult<TValue>(this Either<Error, TValue> result)
            => result
                .Fold(
                    error => error.MapError<TValue>(),
                    value => value);


        public static ActionResult<TModel> ToActionResult<TValue, TModel>(
            this Either<Error, TValue> result,
            Func<TValue, TModel> valueMapper) where TModel : notnull
            => result
                .Fold(
                    error => error.MapError<TModel>(),
                    value => value is Unit ? (ActionResult<TModel>) new NoContentResult() : valueMapper(value));

        private static ActionResult<TModel> MapError<TModel>(this Error error)
            => error.Accept<ResultMappingVisitor<TModel>, ActionResult<TModel>>(
                new ResultMappingVisitor< TModel>());

        private readonly struct ResultMappingVisitor<TModel> : Error.IResultVisitor<ActionResult<TModel>>
        {
            public ActionResult<TModel> Visit(Error.NotFound result)
                => new NotFoundObjectResult(result.Message);

            public ActionResult<TModel> Visit(Error.Invalid result)
                => new BadRequestObjectResult(result.Message);

//        public IActionResult Visit(Error.Unexpected result)
//            => new ObjectResult(result.Message) {StatusCode = (int) HttpStatusCode.InternalServerError};
        }
    }
}