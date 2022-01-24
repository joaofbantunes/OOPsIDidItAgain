using System.ComponentModel;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.ModelBinding;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;

[TypeConverter(typeof(StronglyTypedIdTypeConverter<CartId>))]
public readonly record struct CartId(Guid Value) : IStronglyTypedId<CartId>
{
    public string AsString() => Value.ToString();
    
    public static bool TryParse(string? input, out CartId result)
    {
        if (Guid.TryParse(input, out var value))
        {
            result = new(value);
            return true;
        }

        result = default;
        return false;
    }

    public static CartId New() => new(Guid.NewGuid());
}
