using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.JsonDTOs
{
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonBasketQtyUpdateRequest 
    {
        [DataMember]
        public JsonBasketItemUpdateRequest[] Items { get; set; }
    }
}
