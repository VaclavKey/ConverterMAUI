﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterMAUI
{
    internal class ApiResponse
    {
        public bool Success { get; set; }
        public string BaseCode { get; set; }

        [JsonProperty("conversion_rates")]
        public Dictionary<string, decimal> ConversionRates { get; set; }
    }
}
