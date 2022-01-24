using OOPsIDidItAgain._03.IndividualRequestHandlers.Web.Features.Carts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

// use controllers
app.MapControllers();

// or use endpoints
AddItemToCartEndpoint.MapEndpoint(app);
    
// (or both, they're not mutually exclusive)

app.Run();