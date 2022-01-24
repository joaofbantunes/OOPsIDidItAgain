using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Features;

public static class ResultExtensions
{
    public static IResult ToResult<TResult>(this TResult result) => Results.Ok(result);

    public static IResult ToResult(this Unit result) => Results.NoContent();

    public static IResult ToResult<TValue, TModel>(this Maybe<TValue> result, Func<TValue, TModel> valueMapper)
        => result
            .MapValueOr(
                value => Results.Ok(valueMapper(value)),
                () => Results.NotFound());

    public static IResult ToResult(this Either<Error, Unit> result)
        => result
            .Fold(
                error => error.MapError(),
                _ => Results.NoContent());


    public static IResult ToResult<TValue>(this Either<Error, TValue> result)
        => result
            .Fold(
                error => error.MapError(),
                value => Results.Ok(value));


    public static IResult ToResult<TValue, TModel>(
        this Either<Error, TValue> result,
        Func<TValue, TModel> valueMapper) where TModel : notnull
        => result
            .Fold(
                error => error.MapError(),
                value => value is Unit ? Results.NoContent() : Results.Ok(valueMapper(value)));

    private static IResult MapError(this Error error)
        => error.Accept<ResultMappingVisitor, IResult>(
            new ResultMappingVisitor());

    private readonly struct ResultMappingVisitor : Error.IResultVisitor<IResult>
    {
        public IResult Visit(Error.NotFound result)
            => Results.NotFound(result.Message);

        public IResult Visit(Error.Invalid result)
            => Results.BadRequest(result.Message);

        // public IResult Visit(Error.Unexpected result)
        //     => Results.StatusCode(500);
    }
}