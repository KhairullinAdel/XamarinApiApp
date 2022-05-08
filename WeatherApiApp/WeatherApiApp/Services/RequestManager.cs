using WeatherApiApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApiApp.Services
{
    public class RequestManager
    {
        IRestService restService;
        public RequestManager(IRestService service)
        {
            restService = service;
        }
        public Task<WeatherRoot> GetWeather(string city)
        {
            return restService.GetWeather(city);
        }
    }
}
