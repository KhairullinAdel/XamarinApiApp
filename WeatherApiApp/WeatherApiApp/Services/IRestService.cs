using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services
{
    public interface IRestService
    {
        Task<List<Cat>> GetCatsAsync();
        Task SaveCatAsync(Cat cat, bool isNewItem);
        Task DeleteCatAsync(Cat cat);
    }
}
