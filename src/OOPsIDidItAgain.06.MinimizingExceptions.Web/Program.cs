using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain.PostAddItemToCartListeners;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Features.Carts;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Handlers;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Infrastructure;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.ModelBinding;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Services;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(o =>
{
    o.SerializerOptions.Converters.Add(new StronglyTypedIdJsonConverter<CartId>());
    o.SerializerOptions.Converters.Add(new StronglyTypedIdJsonConverter<ItemId>());
});

builder.Services
    .AddScoped<IRequestHandler<AddItemToCart.Request, Either<Error, Unit>>, AddItemToCart.Handler>()
    .AddScoped<IRequestHandler<GetCart.Request, Maybe<GetCart.Response>>, GetCart.Handler>();

builder.Services
    .Decorate<IRequestHandler<AddItemToCart.Request, Either<Error, Unit>>,
        RequestHandlerLoggingDecorator<AddItemToCart.Request, Either<Error, Unit>>>()
    .Decorate<IRequestHandler<GetCart.Request, Maybe<GetCart.Response>>,
        RequestHandlerLoggingDecorator<GetCart.Request, Maybe<GetCart.Response>>>();

builder.Services
    .AddSingleton<ICartRepository, InMemoryCartRepository>()
    .AddSingleton<IItemRepository, InMemoryItemRepository>()
    .AddSingleton<IItemSaleRuleRepository, InMemoryItemSaleRuleRepository>()
    .AddSingleton<INotifier, LoggingNotifier>()
    .AddSingleton<IPostAddItemToCartListener>(
        s => new CompositePostAddItemToCartListener(
            new[]
            {
                new WatchlistNotifierListener(
                    s.GetRequiredService<INotifier>(),
                    new[] {((Either<Error, ItemId>.Right) ItemId.From("123", "4567890")).Value})
            }));

var app = builder.Build();

AddItemToCartEndpoint.MapEndpoint(app);
GetCartEndpoint.MapEndpoint(app);

app.Run();