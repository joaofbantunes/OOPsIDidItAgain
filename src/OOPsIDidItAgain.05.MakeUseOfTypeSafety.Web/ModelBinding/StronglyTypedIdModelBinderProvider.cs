using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Shared;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.ModelBinding
{
    public class StronglyTypedIdModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            
            if (typeof(IStronglyTypedId).IsAssignableFrom(context.Metadata.ModelType))
            {
                return new BinderTypeModelBinder(typeof(StronglyTypedIdModelBinder));
            }

            return null;
        }
    }
}