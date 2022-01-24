using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.Reflection;

namespace CompanyEmployees.Presentation.ModelBinders
{
    public class ArrayModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (!bindingContext.ModelMetadata.IsEnumerableType)
            {
            bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            //extract the value
            var providedValue = bindingContext.ValueProvider 
                .GetValue(bindingContext.ModelName)
                .ToString();
            if (string.IsNullOrEmpty(providedValue))
            {
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }

            // store the type the IEnumerable consists of
            var genericType = bindingContext.ModelType.GetTypeInfo().GenericTypeArguments[0];
            //create a converter for exact type (GUID in our case)
            var converter = TypeDescriptor.GetConverter(genericType);

            var objectArray = providedValue.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => converter.ConvertFromString(x.Trim()))
                .ToArray();

            var guidArray = Array.CreateInstance(genericType, objectArray.Length);
            objectArray.CopyTo(guidArray, 0);
            bindingContext.Model = guidArray;
            bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
            return Task.CompletedTask;
        }
    }
}
