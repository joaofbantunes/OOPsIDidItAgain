namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Shared;

public sealed class Unit
{
    private Unit()
    {

    }

    public static Unit Instance { get; } = new Unit();
}
