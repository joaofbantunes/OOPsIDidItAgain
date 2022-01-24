using System.Diagnostics.CodeAnalysis;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Shared;

// Simple implementation for demo
// For a fully featured implementation, checkout https://github.com/nlkl/Optional or https://github.com/louthy/language-ext

public static class Maybe
{
    public static Maybe<T> Some<T>(T value) where T : notnull => new(value);

    public static Maybe<T> None<T>() where T : notnull => new();
}

public readonly struct Maybe<T>
{
    private readonly T _value;

    internal Maybe(T value)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value));
        HasValue = true;
    }

    public bool HasValue { get; }

    public T ValueOr(Func<T> alternativeFactory) => HasValue ? _value : alternativeFactory();

    public bool TryGetValue([MaybeNullWhen(false)] out T value)
    {
        value = HasValue ? _value : default;
        return HasValue;
    }
}
