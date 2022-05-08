using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApiApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApiApp.Models;
using Xamarin.Forms.Maps;

namespace WeatherApiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherRoot Weather { get; set; }
        public WeatherPage()
        {
            InitializeComponent();

            Weather = new WeatherRoot();
            this.BindingContext = Weather;
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var city = searchBar.Text;
            Weather = await App.RequestManager.GetWeather(city);

            this.BindingContext = Weather;
        }
    }
}