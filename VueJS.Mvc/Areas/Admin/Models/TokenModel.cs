﻿using System;

namespace VueJS.Mvc.Areas.Admin.Models
{
    public class TokenModel
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}