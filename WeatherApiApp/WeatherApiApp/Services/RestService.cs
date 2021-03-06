using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services
{
    public class RestService : IRestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        public List<Cat> Cats { get; set; }

        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);

            serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task DeleteCatAsync(Cat item)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, item.Id));
            try
            {
                HttpResponseMessage httpResponseMessage = await client.DeleteAsync(uri);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("@@@Success");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"@@@@@@@@@@//// {ex.Message}");
            }
        }

        public async Task<List<Cat>> GetCatsAsync()
        {
            Cats = new List<Cat>();

            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Cats = JsonSerializer.Deserialize<List<Cat>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return Cats;
        }

        public async Task SaveCatAsync(Cat item, bool isNewItem)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {
                string json = JsonSerializer.Serialize(item, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("@@@Success");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
    }
}
