using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Newtonsoft.Json;

namespace ConverterMAUI
{
    internal static class CurrencyConverter
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly MemoryCache _cache = new MemoryCache("CurrencyCache");

        private static readonly string apiKey = "1b29b58f1aa826b79ead3bb5";
        private static readonly string apiUrl = "https://v6.exchangerate-api.com/v6/{0}/latest/{1}"; // API для получения курсов валют

        public static async Task<decimal?> GetConversionRateAsync(string fromCurrency, string toCurrency)
        {
            string cacheKey = $"conversion_rate_{fromCurrency}_to_{toCurrency}";

            if (_cache.Contains(cacheKey))
            {
                Console.WriteLine("Data received from cache.");
                return (decimal?)_cache.Get(cacheKey);
            }


            Console.WriteLine("Data received from API.");

            string url = string.Format(apiUrl, apiKey, fromCurrency);
            Console.WriteLine(url);
            var response = await _httpClient.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<ApiResponse>(response);

            if (data?.ConversionRates != null && data.ConversionRates.ContainsKey(toCurrency))
            {
                var rate = data.ConversionRates[toCurrency];

                _cache.Add(cacheKey, rate, DateTime.Now.AddHours(1));
                Console.WriteLine("Cache added");
                return rate;
            }

            return null;
        }
    }

}
