using System.Globalization;
using System;
using System.Web.Mvc;

namespace UserJobsTracker
{
    public class DateTimeModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value != null)
            {
                var dateFormat = "dd/MM/yyyy"; // Define the format you expect from the client side
                if (DateTime.TryParseExact(value.AttemptedValue, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
                {
                    return dateTime;
                }
            }
            return null;
        }
    }
}