namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;

public abstract record ErrorDetail
{
    private ErrorDetail()
    {
    }

    public abstract TVisitResult Accept<TVisitResult>(IResultVisitor<TVisitResult> visitor);

    public interface IResultVisitor<out TVisitResult>
    {
        TVisitResult Visit(NotFound result);

        TVisitResult Visit(Invalid result);

        //TVisitResult Visit(Unexpected result);
    }

    public sealed record NotFound(string Message) : ErrorDetail
    {
        public override TVisitResult Accept<TVisitResult>(IResultVisitor<TVisitResult> visitor)
            => visitor.Visit(this);
    }

    public sealed record Invalid(string Message) : ErrorDetail
    {
        public override TVisitResult Accept<TVisitResult>(IResultVisitor<TVisitResult> visitor)
            => visitor.Visit(this);
    }

    // public sealed record Unexpected(string Message) : ErrorDetail
    // {
    //     public override TVisitResult Accept<TVisitResult>(IResultVisitor<TVisitResult> visitor)
    //         => visitor.Visit(this);
    // }
}
