namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

public abstract record Error
{
    private Error()
    {
    }

    public abstract TResult Accept<TVisitor, TResult>(TVisitor visitor)
        where TVisitor : IResultVisitor<TResult>;

    public interface IResultVisitor<out TVisitResult>
    {
        TVisitResult Visit(NotFound result);

        TVisitResult Visit(Invalid result);

        //TVisitResult Visit(Unexpected result);
    }

    public sealed record NotFound(string Message) : Error
    {
        public override TVisitResult Accept<TResultVisitor, TVisitResult>(TResultVisitor visitor)
            => visitor.Visit(this);
    }

    public sealed record Invalid(string Message) : Error
    {
        public override TVisitResult Accept<TResultVisitor, TVisitResult>(TResultVisitor visitor)
            => visitor.Visit(this);
    }

    // public sealed record Unexpected(string Message) : Error
    // {
    //     public override TVisitResult Accept<TResultVisitor, TVisitResult>(TResultVisitor visitor)
    //         => visitor.Visit(this);
    // }
}
