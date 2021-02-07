namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Handlers
{
    public interface IRequestHandler<TIn, TOut> where TIn : IRequest<TOut>
    {
        TOut Handle(TIn input);
    }
}