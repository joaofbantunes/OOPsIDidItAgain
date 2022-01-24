namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

public static class MaybeExtensions
{
    public static TOut MapValueOr<TIn, TOut>(this Maybe<TIn> maybeValue, Func<TIn, TOut> some, Func<TOut> none)
    {
        if (some is null) throw new ArgumentNullException(nameof(some));
        if (none is null) throw new ArgumentNullException(nameof(none));

        return maybeValue.TryGetValue(out var value)
            ? some(value)
            : none();
    }
}