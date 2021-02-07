namespace OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Handlers
{
    public interface IRequestHandler<TIn, TOut> where TIn : IRequest<TOut>
    {
        TOut Handle(TIn input);
    }
}