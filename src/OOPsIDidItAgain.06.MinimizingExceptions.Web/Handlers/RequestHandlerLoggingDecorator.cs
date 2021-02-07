using Microsoft.Extensions.Logging;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Handlers
{
    public class RequestHandlerLoggingDecorator<TIn, TOut> : IRequestHandler<TIn, TOut> where TIn : IRequest<TOut>
    {
        private readonly IRequestHandler<TIn, TOut> _next;
        private readonly ILogger<RequestHandlerLoggingDecorator<TIn, TOut>> _logger;

        public RequestHandlerLoggingDecorator(IRequestHandler<TIn, TOut> next, ILogger<RequestHandlerLoggingDecorator<TIn, TOut>> logger)
        {
            _next = next;
            _logger = logger;
        }
        
        public TOut Handle(TIn input)
        {
            try
            {
                _logger.LogTrace("Handling {requestName}", typeof(TIn).Name);
                return _next.Handle(input);
            }
            finally
            {
                _logger.LogTrace("Done handling {requestName}", typeof(TIn).Name);
            }
        }
    }
}