﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.Models
{
   public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {

            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }
}
