using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain.PostAddItemToCartListeners;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Handlers;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Infrastructure;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.ModelBinding;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Services;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers(options => options.ModelBinderProviders.Insert(0, new StronglyTypedIdModelBinderProvider()))
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new StronglyTypedIdConverter()));

            services
                .AddScoped<IRequestHandler<AddItemToCartRequest, Either<Error, Unit>>, AddItemToCartHandler>()
                .AddScoped<IRequestHandler<GetCartRequest, Either<Error, GetCartResponse>>, GetCartHandler>();

            services
                .Decorate<IRequestHandler<AddItemToCartRequest, Either<Error, Unit>>,
                    RequestHandlerLoggingDecorator<AddItemToCartRequest, Either<Error, Unit>>>()
                .Decorate<IRequestHandler<GetCartRequest, Either<Error, GetCartResponse>>,
                    RequestHandlerLoggingDecorator<GetCartRequest, Either<Error, GetCartResponse>>>();
            services
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
                                new[] {new ItemId(Guid.Parse("2f823b5c-f93e-431e-a64c-a59f407d236f"))})
                        }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}