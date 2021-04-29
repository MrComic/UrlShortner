﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortner.Core.Domain.Exceptions
{
    public class CustomExceptionsBase:Exception
    {
        public CustomExceptionsBase(string message) : base(message)
        {
        }

        public CustomExceptionsBase(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
