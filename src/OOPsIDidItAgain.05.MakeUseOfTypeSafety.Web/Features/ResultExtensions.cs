using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Shared;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Features;

public static class ResultExtensions
{
    public static IResult ToResult<TResult>(this TResult result) => Results.Ok(result);

    public static IResult ToResult(this Unit result) => Results.NoContent();
}