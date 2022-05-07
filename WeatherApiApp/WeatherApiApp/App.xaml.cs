using System;
using WeatherApiApp.Services;
using WeatherApiApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApiApp
{
    public partial class App : Application
    {
        public static TodoManager TodoManager { get; set; }

        public App()
        {
            InitializeComponent();

            TodoManager = new TodoManager(new RestService());
            MainPage = new NavigationPage(new TodoListPage());
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
