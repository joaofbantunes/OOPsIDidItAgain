namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;

public readonly record struct CartId(Guid Value)
{
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
