using OOPsIDidItAgain._04.OOifying.Web.Features.Carts;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

AddItemToCartEndpoint.MapEndpoint(app);

app.Run();