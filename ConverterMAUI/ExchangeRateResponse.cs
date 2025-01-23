using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterMAUI
{
    public class ExchangeRateResponse
    {
        [JsonProperty("conversion_rates")]
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
