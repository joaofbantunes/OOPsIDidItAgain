using System;
using System.Diagnostics.CodeAnalysis;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain
{
    /*
     * Records are a quick way to implement strongly typed ids (and other techniques against primitive obsession), but not necessarily always the best.
     * For an interesting approach using structs, take a look at: https://andrewlock.net/using-strongly-typed-entity-ids-to-avoid-primitive-obsession-part-1/
     */
    public sealed record ItemId(Guid Value) : IStronglyTypedId
    {
        public static bool TryParse(string? input, [MaybeNullWhen(false)] out ItemId output)
        {
            if (Guid.TryParse(input, out var value))
            {
                output = new(value);
                return true;
            }

            output = null;
            return false;
        }

        public static ItemId New() => new(Guid.NewGuid());
    }
}