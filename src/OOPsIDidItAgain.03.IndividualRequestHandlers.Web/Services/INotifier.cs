using System;

namespace OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Services
{
    public interface INotifier
    {
        void Notify(Guid itemId);
    }
}