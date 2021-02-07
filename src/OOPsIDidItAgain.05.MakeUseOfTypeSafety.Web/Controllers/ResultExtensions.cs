using Microsoft.AspNetCore.Mvc;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Shared;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Controllers
{
    public static class ResultExtensions
    {
        public static ActionResult<TResult> ToActionResult<TResult>(this TResult result)
            => new OkObjectResult(result);
        
        public static IActionResult ToActionResult(this Unit result)
            => new NoContentResult();
    }
}