using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Domain;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Middlewares;

public class ResultMappingErrorVisitor : ErrorDetail.IResultVisitor<IResult>
{
    public IResult Visit(ErrorDetail.NotFound result)
        => Results.NotFound(result.Message);

    public IResult Visit(ErrorDetail.Invalid result)
        => Results.BadRequest(result.Message);

    // public IResult Visit(ErrorDetail.Unexpected result)
    //     => Results.StatusCode(500);
}