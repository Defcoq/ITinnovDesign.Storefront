﻿using ITinnovDesign.Storefront.Services.Messaging.ProductCatalogService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ITinnovDesign.Storefront.Controllers.JsonDTOs
{
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonProductSearchRequest
    {
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public int[] ColorIds { get; set; }
        [DataMember]
        public int[] SizeIds { get; set; }
        [DataMember]
        public int[] BrandIds { get; set; }
        [DataMember]
        public ProductsSortBy SortBy { get; set; }
        [DataMember]
        public IEnumerable<JsonRefinementGroup> RefinementGroups { get; set; }
        [DataMember]
        public int Index { get; set; }
    }
}
