using Microsoft.Extensions.Logging;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Services;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Infrastructure
{
    public class LoggingNotifier : INotifier
    {
        private readonly ILogger<LoggingNotifier> _logger;

        public LoggingNotifier(ILogger<LoggingNotifier> logger) => _logger = logger;

        public void Notify(ItemId itemId)
        {
            _logger.LogDebug(itemId.ToString());
        }
    }
}