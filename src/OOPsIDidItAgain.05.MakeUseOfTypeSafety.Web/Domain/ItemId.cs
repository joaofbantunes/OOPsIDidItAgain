using System.Text.RegularExpressions;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;

public readonly record struct ItemId
{
    private static readonly Regex Regex = new("^(\\d{3})-(\\d{7})$", RegexOptions.Compiled);

    private ItemId(string prefix, string suffix)
    {
        Prefix = prefix;
        Suffix = suffix;
    }

    public string Prefix { get; }

    public string Suffix { get; }

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
}