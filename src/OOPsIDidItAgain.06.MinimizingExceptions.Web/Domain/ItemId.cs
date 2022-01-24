using System.ComponentModel;
using System.Text.RegularExpressions;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.ModelBinding;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;

[TypeConverter(typeof(StronglyTypedIdTypeConverter<ItemId>))]
public readonly record struct ItemId : IStronglyTypedId<ItemId>
{
    private static readonly Regex Regex = new("^(\\d{3})-(\\d{7})$", RegexOptions.Compiled);

    private ItemId(string prefix, string suffix)
    {
        Prefix = prefix;
        Suffix = suffix;
    }

    public string Prefix { get; }

    public string Suffix { get; }

    public string AsString() => $"{Prefix}-{Suffix}";

    public static bool TryParse(string? input, out ItemId result)
    {
        Match match;
        if (!string.IsNullOrWhiteSpace(input) && (match = Regex.Match(input)).Success)
        {
            result = new(match.Groups[1].Value, match.Groups[2].Value);
            return true;
        }

        result = default;
        return false;
    }

    public static Either<Error, ItemId> From(string prefix, string suffix)
    {
        var errorList = new List<string>(2);
        
        if (prefix.Length != 3 || !int.TryParse(prefix, out _))
        {
            errorList.Add("Invalid prefix.");
        }
        
        if (suffix.Length != 7 || !int.TryParse(suffix, out _))
        {
            errorList.Add("Invalid suffix.");
        }

        return errorList.Count > 0
            ? Either.Left<Error, ItemId>(new Error.Invalid(string.Join(" ", errorList)))
            : Either.Right<Error, ItemId>(new ItemId(prefix, suffix));
    }
}