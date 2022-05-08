using System;
using WeatherApiApp.Services;
using WeatherApiApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApiApp
{
    public partial class App : Application
    {
        public static RequestManager RequestManager { get; private set; }

        public App()
        {
            InitializeComponent();

            RequestManager = new RequestManager(new RestService());
            MainPage = new NavigationPage(new WeatherPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
