namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Handlers
{
    public interface IRequestHandler<TIn, TOut> where TIn : IRequest<TOut>
    {
        TOut Handle(TIn input);
    }
}