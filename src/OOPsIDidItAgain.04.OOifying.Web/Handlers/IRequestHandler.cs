namespace OOPsIDidItAgain._04.OOifying.Web.Handlers
{
    public interface IRequestHandler<TIn, TOut> where TIn : IRequest<TOut>
    {
        TOut Handle(TIn input);
    }
}