﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortner.Endpoints.Api.Model
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data{ get; set; }
        public string Message { get; set; }
    }
}
