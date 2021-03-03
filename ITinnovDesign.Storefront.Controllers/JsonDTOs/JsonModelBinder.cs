using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ITinnovDesign.Storefront.Controllers.JsonDTOs
{
    public class JsonModelBinder : IModelBinder
    {
       

        public  Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext");

            string valueFromBody = string.Empty;

            using (var sr = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                valueFromBody =  sr.ReadToEndAsync().Result;
            }

            if (string.IsNullOrEmpty(valueFromBody))
            {
                return Task.CompletedTask;
            }
            var ModelType = bindingContext.ModelType;
            if(ModelType  == typeof(JsonProductSearchRequest))
            {
                var jsonProductSearchRequest = JsonConvert.DeserializeObject<JsonProductSearchRequest>(valueFromBody);
                bindingContext.Result = ModelBindingResult.Success(jsonProductSearchRequest);
            }

            if (ModelType == typeof(JsonBasketItemUpdateRequest))
            {
                var jsonBasketItemUpdateRequest = JsonConvert.DeserializeObject<JsonBasketItemUpdateRequest>(valueFromBody);
                bindingContext.Result = ModelBindingResult.Success(jsonBasketItemUpdateRequest);
            }

            if (ModelType == typeof(JsonBasketQtyUpdateRequest))
            {
                var jsonBasketQtyUpdateRequest = JsonConvert.DeserializeObject<JsonBasketQtyUpdateRequest>(valueFromBody);
                bindingContext.Result = ModelBindingResult.Success(jsonBasketQtyUpdateRequest);
            }
            // string values = Convert.ToString(((JValue)JObject.Parse(valueFromBody)["value"]).Value);


            return Task.CompletedTask;

        }
    }
}
