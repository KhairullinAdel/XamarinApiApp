using System;
using System.Collections.Generic;
using System.Text;
using WeatherApiApp.Models;
using System.Threading.Tasks;

namespace WeatherApiApp.Services
{
    public interface IRestService
    {
        Task<WeatherRoot> GetWeather(string city);
    }
}
