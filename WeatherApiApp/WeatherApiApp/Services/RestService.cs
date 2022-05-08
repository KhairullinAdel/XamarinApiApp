using WeatherApiApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace WeatherApiApp.Services
{
    public class RestService : IRestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        WeatherRoot Weather { get; set; }
        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            client = new HttpClient(httpClientHandler);

            serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<WeatherRoot> GetWeather(string city)
        {
            Uri uri = new Uri($"{Constants.RestUrl}?q={city}&appid={Constants.GetApiKey()}&units=metric");
            try
            {
                Debug.WriteLine("Start Requests");
                HttpResponseMessage responseMessage = await client.GetAsync(uri);
                Debug.WriteLine("End Request");

                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = await responseMessage.Content.ReadAsStringAsync();
                    Weather = JsonSerializer.Deserialize<WeatherRoot>(content, serializerOptions);
                }
                else
                {
                    Debug.WriteLine("Bad Requset");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return Weather;
        }
    }
}