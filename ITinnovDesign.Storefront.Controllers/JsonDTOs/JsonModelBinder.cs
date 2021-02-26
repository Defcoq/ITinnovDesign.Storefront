using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ITinnovDesign.Storefront.Controllers.JsonDTOs
{
    public class JsonModelBinder : IModelBinder
    {
       

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext");
            var serializer = new DataContractJsonSerializer(bindingContext.ModelType);
            //using (Stream s = await wc.OpenReadTaskAsync("https://example.com/sample.json"))
            //{
            //    record = ser.ReadObject(s) as Example;
            //}
            //var esitoSerializeInJson = JsonConvert.SerializeObject(esito);
            bindingContext.Result = ModelBindingResult.Success(serializer.ReadObject(bindingContext.HttpContext.Request.Body));

            return Task.CompletedTask;

        }
    }
}
