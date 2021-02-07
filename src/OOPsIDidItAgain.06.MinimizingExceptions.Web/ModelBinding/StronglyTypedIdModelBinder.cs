using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.ModelBinding
{
    public class StronglyTypedIdModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            var value = valueProviderResult.FirstValue;

            // not good for prod, but good enough for a demo 🙂
            if (bindingContext.ModelType == typeof(CartId) && CartId.TryParse(value, out var cartId))
            {
                bindingContext.Result = ModelBindingResult.Success(cartId);
            }
            else if (bindingContext.ModelType == typeof(ItemId) && ItemId.TryParse(value, out var itemId))
            {
                bindingContext.Result = ModelBindingResult.Success(itemId);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }
    }
}