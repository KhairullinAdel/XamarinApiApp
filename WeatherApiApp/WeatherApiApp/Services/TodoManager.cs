using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services
{
    public class TodoManager
    {
        IRestService service;

        public TodoManager(IRestService restService)
        {
            service = restService;
        }
        public Task<List<Cat>> GetCatItemModels()
        {
            return service.GetCatsAsync();
        }

        public Task DeleteCatAsync(Cat item)
        {
            return service.DeleteCatAsync(item);
        }
        public Task SaveCatAsync(Cat todoItem, bool isNewItem = false)
        {
            return service.SaveCatAsync(todoItem, isNewItem);
        }
    }
}
