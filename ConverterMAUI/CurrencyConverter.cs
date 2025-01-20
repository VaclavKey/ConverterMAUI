using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Newtonsoft.Json;
using Microsoft.Data.Sqlite;
namespace ConverterMAUI
{
    internal static class CurrencyConverter
    {
        public static List<string> Currencies = new List<string>
        {
            "RUB",
            "USD",
            "EUR",
            "GBP",
            "JPY",
            "BYN",
            "PLN",
            "CNY",
            "TRY",
            "KZT"
        };

        private const string connectionString = $"Data Source=ExchangeRates.db";
        private static readonly HttpClient _httpClient = new HttpClient();

        private static readonly string apiKey = "1b29b58f1aa826b79ead3bb5";
        private static readonly string apiUrl = "https://v6.exchangerate-api.com/v6/{0}/latest/{1}"; // API для получения курсов валют

        public static async Task InitializeDB()
        {
            if (!TableExists())
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();


                    string createTableQuery = @"
                    CREATE TABLE ExchangeRates 
                    (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FromCurrency TEXT NOT NULL,
                        ToCurrency TEXT NOT NULL,
                        Rate REAL NOT NULL
                    );";

                    using (var command = new SqliteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            await UpdateDB();
        }

        public static async Task UpdateDB()
        {
            ClearDB();

            for (int i = 0; i < 10; i++)
            {
                string fromCur = Currencies[i];
                for (int j = 0; j < 10; j++)
                {
                    var rate = await GetConversionRateAsync(Currencies[i], Currencies[j]);
                    string toCur = Currencies[j];

                    using (var connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();

                        //Console.WriteLine(fromCur + " -> " + toCur + " = " + rate.ToString());
                        string insertQuery = "INSERT INTO ExchangeRates (FromCurrency, ToCurrency, Rate) VALUES (@fromCur, @toCur, @rate);";
                        using (var command = new SqliteCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("fromCur", fromCur);
                            command.Parameters.AddWithValue("@toCur", toCur);
                            command.Parameters.AddWithValue("rate", rate);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static async Task ReadDB()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM ExchangeRates";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[1]} -> {reader[2]} = {reader[3]}");
                        }
                    }
                }
            }
        }

        public static async Task ClearDB()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM ExchangeRates";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool TableExists()
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT name FROM sqlite_master WHERE type='table' AND name = 'ExchangeRates'";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    return (result != null) ? true : false;
                }
            }
        }
        public static async Task<decimal?> GetConversionRateAsync(string fromCurrency, string toCurrency)
        {
            string url = string.Format(apiUrl, apiKey, fromCurrency);
            var response = await _httpClient.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<ApiResponse>(response);

            if (data?.ConversionRates != null && data.ConversionRates.ContainsKey(toCurrency))
            {
                var rate = data.ConversionRates[toCurrency];
                return rate;
            }

            return null;
        }

        public static async Task<decimal?> GetRate(string fromCurrency, string toCurrency)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT Rate FROM ExchangeRates WHERE FromCurrency = '{fromCurrency}' and ToCurrency = '{toCurrency}'";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return Convert.ToDecimal(reader[0]);
                        }
                    }
                }
            }
            return 0;
        }
    }

}
