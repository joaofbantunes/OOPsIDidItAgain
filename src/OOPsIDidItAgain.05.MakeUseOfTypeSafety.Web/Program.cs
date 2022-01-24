using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Features.Carts;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ExceptionHandlingMiddleware>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

AddItemToCartEndpoint.MapEndpoint(app);

app.Run();