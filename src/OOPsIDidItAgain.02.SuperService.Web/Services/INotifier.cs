using System;

namespace OOPsIDidItAgain._02.SuperService.Web.Services
{
    public interface INotifier
    {
        void Notify(Guid itemId);
    }
}