using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.JsonDTOs
{
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonRefinementGroup
    {
        [DataMember]
        public int GroupId { get; set; }

        [DataMember]
        public int[] SelectedRefinements { get; set; }
    }

}
