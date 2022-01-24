namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

public static class EitherExtensions
{
    public static TOut Fold<TLeftIn, TRightIn, TOut>(
        this Either<TLeftIn, TRightIn> result,
        Func<TLeftIn, TOut> left,
        Func<TRightIn, TOut> right)
    {
        Require.NotNull(result, nameof(result));
        Require.NotNull(left, nameof(left));
        Require.NotNull(right, nameof(right));

        return result switch
        {
            Either<TLeftIn, TRightIn>.Left error => left(error.Value),
            Either<TLeftIn, TRightIn>.Right success => right(success.Value),
            _ => throw CreateUnexpectedResultTypeException(nameof(result))
        };
    }

    public static Either<TLeft, TRightOut> Map<TLeft, TRightIn, TRightOut>(
        this Either<TLeft, TRightIn> result,
        Func<TRightIn, TRightOut> right)
    {
        Require.NotNull(result, nameof(result));
        Require.NotNull(right, nameof(right));

        return result switch
        {
            Either<TLeft, TRightIn>.Left error => Either.Left<TLeft, TRightOut>(error.Value),
            Either<TLeft, TRightIn>.Right success => Either.Right<TLeft, TRightOut>(right(success.Value)),
            _ => throw CreateUnexpectedResultTypeException(nameof(result))
        };
    }

    public static Either<TLeft, TRight> Do<TLeft, TRight>(
        this Either<TLeft, TRight> result,
        Action<TRight> action)
    {
        Require.NotNull(result, nameof(result));
        Require.NotNull(action, nameof(action));

        if (result is Either<TLeft, TRight>.Right right)
        {
            action(right.Value);
        }

        return result;
    }

    public static Either<TLeft, TRightOut> FlatMap<TLeft, TRightIn, TRightOut>(
        this Either<TLeft, TRightIn> result,
        Func<TRightIn, Either<TLeft, TRightOut>> right)
    {
        Require.NotNull(result, nameof(result));
        Require.NotNull(right, nameof(right));

        return result switch
        {
            Either<TLeft, TRightIn>.Left error => Either.Left<TLeft, TRightOut>(error.Value),
            Either<TLeft, TRightIn>.Right success => right(success.Value),
            _ => throw CreateUnexpectedResultTypeException(nameof(result))
        };
    }

    private static Exception CreateUnexpectedResultTypeException(string parameterName)
        => new ArgumentOutOfRangeException(
            parameterName,
            "Should never happen -> Either is always Left or Right");
}
