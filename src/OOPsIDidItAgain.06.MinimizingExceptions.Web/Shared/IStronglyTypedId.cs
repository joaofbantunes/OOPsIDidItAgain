using System;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared
{
    public interface IStronglyTypedId
    {
        Guid Value { get; } // to simplify the demo, hardcoded to Guid
    }
}