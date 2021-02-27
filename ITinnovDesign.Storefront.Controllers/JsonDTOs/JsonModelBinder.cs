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
            var serializer = new DataContractJsonSerializer(bindingContext.ModelType);
            //using (Stream s = await wc.OpenReadTaskAsync("https://example.com/sample.json"))
            //{
            //    record = ser.ReadObject(s) as Example;
            //}
            //var esitoSerializeInJson = JsonConvert.SerializeObject(esito);

            string valueFromBody = string.Empty;

            using (var sr = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                valueFromBody =  sr.ReadToEndAsync().Result;
            }

            if (string.IsNullOrEmpty(valueFromBody))
            {
                return Task.CompletedTask;
            }

           // string values = Convert.ToString(((JValue)JObject.Parse(valueFromBody)["value"]).Value);
            var jsonProductSearchRequest = JsonConvert.DeserializeObject<JsonProductSearchRequest>(valueFromBody);
            bindingContext.Result = ModelBindingResult.Success(jsonProductSearchRequest);

            return Task.CompletedTask;

        }
    }
}
