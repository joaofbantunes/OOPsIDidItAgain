using System;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Shared
{
    public static class Require
    {
        public static void NotNull<T>(T input, string parameterName) where T : class
        {
            if (input is null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}