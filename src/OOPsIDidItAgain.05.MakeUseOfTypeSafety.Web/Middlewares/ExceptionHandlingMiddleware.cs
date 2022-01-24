using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ResultMappingErrorVisitor _resultMappingErrorVisitor;

    public ExceptionHandlingMiddleware() => _resultMappingErrorVisitor = new ResultMappingErrorVisitor();

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (DomainException domainException)
        {
            var result = domainException.ErrorDetail.Accept(_resultMappingErrorVisitor);
            await result.ExecuteAsync(context);
        }
    }
}