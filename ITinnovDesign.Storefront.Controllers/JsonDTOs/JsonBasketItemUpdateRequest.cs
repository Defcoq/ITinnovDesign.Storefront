using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.JsonDTOs
{
 
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonBasketItemUpdateRequest
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int Qty { get; set; }
    }
}
