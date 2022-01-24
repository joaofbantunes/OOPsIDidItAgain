using System.Runtime.CompilerServices;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

public static class Require
{
    public static void NotNull<T>(
        T input,
        [CallerArgumentExpression("input")] string? parameterName = null)
        where T : class
    {
        if (input is null)
        {
            throw new ArgumentNullException(parameterName);
        }
    }

    public static void NotDefault<T>(
        T input,
        [CallerArgumentExpression("input")] string? parameterName = null)
        where T : IEquatable<T>
    {
        if (input.Equals(default))
        {
            throw new ArgumentException("Unexpected default value", parameterName);
        }
    }
}