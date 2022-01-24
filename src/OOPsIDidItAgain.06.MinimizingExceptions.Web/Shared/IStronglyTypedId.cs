using System.Diagnostics.CodeAnalysis;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

public interface IStronglyTypedId<TId>
{
    static abstract bool TryParse(string? input, [MaybeNullWhen(false)] out TId result);

    string AsString();
}
