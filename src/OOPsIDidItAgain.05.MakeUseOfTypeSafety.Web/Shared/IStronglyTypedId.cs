using System;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Shared
{
    public interface IStronglyTypedId
    {
        Guid Value { get; } // to simplify the demo, hardcoded to Guid
    }
}