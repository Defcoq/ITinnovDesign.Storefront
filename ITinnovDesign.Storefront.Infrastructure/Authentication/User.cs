﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ITinnovDesign.Storefront.Infrastructure.Authentication
{
    public class User
    {
        public string AuthenticationToken { get; set; }
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
